using Frame.Service.Navigates;
using Frame.Web.Framework.Controllers;
using Frame.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frame.Admin.Controllers
{
    public class CommonController : BaseController
    {
        private readonly INavigateService _navigateService;
        public CommonController(INavigateService navigateService)
        {
            _navigateService = navigateService;
        }


        [ActionAuthorize("HomeIndex")]
        public ActionResult SideBar()
        {
            var navigates = _navigateService.GetPermissionModels();
            return PartialView("_Sidebar", navigates);
        }

        public ActionResult Get()
        {
            return View();
        }

       
	}
}