using Frame.Core;
using Frame.Service.Models.Users;
using Frame.Service.Users;
using Frame.Util;
using Frame.Web.Framework.Controllers;
using Frame.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace Frame.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        public AccountController(ICustomerService customerService,
            IWorkContext workContext)
        {
            _customerService = customerService;
            _workContext = workContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ErrorNotification("验证码错误");
                return View();
            }
            var passWod = SignUtil.MD5Sign(model.PassWord);
            var customer = _customerService.GetCustomer(model.Email, passWod);
            if (customer == null)
            {
                ErrorNotification("用户名或密码错误");
            }
            else
            {
                _workContext.CurrentCustomer = customer;
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}