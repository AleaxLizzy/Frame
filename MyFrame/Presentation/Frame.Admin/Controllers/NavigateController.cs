using Frame.Core.Domain.Navigates;
using Frame.Service.Models.Navitages;
using Frame.Service.Navigates;
using Frame.Service.Security;
using Frame.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frame.Util.Extension;
using Frame.Web.Framework.Security;
namespace Frame.Admin.Controllers
{
    public class NavigateController : BaseController
    {
        private readonly INavigateService _navigateService;
        private readonly IEntityPermissionService _entityPermissionService;
        public NavigateController(INavigateService navigateService,
            IEntityPermissionService entityPermissionService)
        {
            _navigateService = navigateService;
            _entityPermissionService = entityPermissionService;
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var models = _navigateService.GetModelByCnd(new NavigateCndModel());
            return View(models);
        }

        [ActionAuthorize("NavigateList")]
        [HttpPost]
        public ActionResult AjaxList(int id = 0)
        {
            var cnd = new NavigateCndModel { PageSize = 100, ParentdId = id };
            var models = _navigateService.GetModelByCnd(cnd);
            return Json(new { rows = models });
        }
    }
}