using Frame.Core.Domain.Users;
using Frame.Service.Users;
using Frame.Service.Users.Model;
using Frame.Web.Framework.Controllers;
using Frame.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frame.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerSerice;
        private readonly IRoleService _roleService;
        public CustomerController(ICustomerService customerSerice,
            IRoleService roleService)
        {
            _customerSerice = customerSerice;
            _roleService = roleService;
        }
        //
        // GET: /Customer/
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        [ActionAuthorize("CustomerList")]
        public ActionResult AjaxGetUserList(CustomerCndModel cnd)
        {
            var data = _customerSerice.GetModels(cnd);
            return Json(new { rows = data, total = data.TotalCount });
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            var model = new CustomerModel();
            if (id > 0)
            {
                model = _customerSerice.GetModel(id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            if (_customerSerice.ExistEamil(model.Email, model.Id))
            {
                ErrorNotification("邮箱已存在！");
                return View(model);
            }
            if (_customerSerice.ExistName(model.Name, model.Id))
            {
                ErrorNotification("用户名已存在！");
                return View(model);
            }
            model.Type = CustomerTypeEnum.Admin;
            if (_customerSerice.AddOrUpdate(model))
            {
                SuccessNotification("保存成功！");
            }
            return RedirectToAction("List");
        }


        public ActionResult Delete(List<int> ids)
        {
            if (_customerSerice.Delete(ids))
            {
                SuccessNotification("删除成功！");
                return Json(new { success = true });
            }
            else
            {
                ErrorNotification("删除失败！");
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public ActionResult Grant(int id)
        {
            var customer = _customerSerice.Get(id);
            var roles = _roleService.Roles();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListGroup selectListGroup = new SelectListGroup
            {
                Name = customer.Name
            };
            selectListItems.AddRange(roles.Select(x => new SelectListItem
            {
                Group=selectListGroup,
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = customer.Roles.Any(y => y.Id == x.Id)
            }));
            return View(new SelectList(selectListItems));
        }

        [HttpPost]
        public ActionResult Grant(int customerId,IEnumerable<int> roleIds)
        {
            roleIds = roleIds ?? Enumerable.Empty<int>();
            if(_customerSerice.Grant(customerId,roleIds.ToList()))
            SuccessNotification("保存成功");
            return Grant(customerId);
        }
    }
}