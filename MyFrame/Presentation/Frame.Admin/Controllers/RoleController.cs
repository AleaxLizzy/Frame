using Frame.Service.Models.Role;
using Frame.Service.Models.Role.CndModel;
using Frame.Service.Permissions;
using Frame.Service.Users;
using Frame.Web.Framework.Controllers;
using Frame.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frame.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        public RoleController(IRoleService roleService,
             IPermissionService permissionService)
        {
            _roleService = roleService;
            _permissionService = permissionService;
        }
        //
        // GET: /Customer/
        public ActionResult RoleList()
        {
            return View();
        }

        [ActionAuthorize("RoleRoleList")]
        public ActionResult AjaxGetRoleList(RoleCndModel cnd)
        {
            var data = _roleService.GetRoles(cnd);
            return Json(new { rows = data, total = data.TotalCount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(List<int> ids)
        {
            if (_roleService.Delete(ids) == ids.Count)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            RoleModel model = new RoleModel();
            if (id > 0)
            {
                model = _roleService.GetModel(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RoleModel model)
        {
            if (_roleService.ExisSystemName(model.SystemName, model.Id))
            {
                WarringNotification("系统名称已存在！");
                return View(model);
            }
            if (_roleService.ExistName(model.Name, model.Id))
            {
                WarringNotification("角色名称已存在！");
                return View(model);
            }
            if (_roleService.AddOrUpdate(model) > 0)
            {
                SuccessNotification("保存成功！");
                return RedirectToAction("RoleList");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Grant(int id)
        {
            var currentRole = _roleService.GetRole(id);
            var systemName = currentRole.SystemName.Split('_')[0];
            var groups = _permissionService.GetPsermissions(systemName).GroupBy(x => x.Category);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var group in groups)
            {
                SelectListGroup selectListGroup = new SelectListGroup
                {
                    Name = group.Key
                };
                selectListItems.AddRange(group.Select(g => new SelectListItem
                {
                    Group = selectListGroup,
                    Selected = currentRole.Permissions.Any(x => x.Id == g.Id),
                    Value = g.Id.ToString(),
                    Text = g.Name
                }));
            }
            return View(new SelectList(selectListItems));
        }

        [HttpPost]
        public ActionResult Grant(int roleId, IEnumerable<int> permissionIds)
        {
            permissionIds = permissionIds ?? Enumerable.Empty<int>();
            if (_roleService.Update(roleId, permissionIds.ToList()))
            {
                SuccessNotification("保存成功!");
            }
            else {
                ErrorNotification("保存失败!");
            }
            return Grant(roleId);
        }
    }
}