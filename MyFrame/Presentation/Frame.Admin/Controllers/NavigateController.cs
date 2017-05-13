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
            return View();
        }

    }
}