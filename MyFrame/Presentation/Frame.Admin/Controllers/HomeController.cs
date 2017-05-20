using Frame.Core;
using Frame.Web.Framework.Controllers;
using Frame.Web.Framework.Security;
using Frame.Web.Framework.UI;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frame.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IWorkContext _workContext;
        public HomeController(IWorkContext workContext)
        {
            _workContext = workContext;
        }
        public ActionResult Index()
        {
            try
            {
                Test();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return View();
        }

        private void Test()
        {
            throw new DivideByZeroException();
        }
    }
}