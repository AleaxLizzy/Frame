using Frame.Core.Domain.Users;
using Frame.Data.Cache;
using Frame.Service.Users;
using Frame.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frame.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly ICacheService _cacheService;
        public HomeController(ICustomerService customerService,
            ICacheService cacheService)
        {
            _customerService = customerService;
            _cacheService = cacheService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}