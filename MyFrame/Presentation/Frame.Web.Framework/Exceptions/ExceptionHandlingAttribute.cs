using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

using Frame.Core.Infrastructure;
using System.Web.Routing;
using System.Web;
namespace Frame.Web.Framework.Exceptions
{

    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public string ExceptionPolicyName { get; private set; }

        public ExceptionHandlingAttribute(string exceptionPolicyName = "defaultPolicy")
        {
            this.ExceptionPolicyName = exceptionPolicyName;
        }
        public override void OnException(ExceptionContext filterContext)
        {
            try
            {
                ExceptionPolicy.HandleException(filterContext.Exception, ExceptionPolicyName);
                var exception = filterContext.Exception;
                filterContext.Result = new JsonResult() { Data = new { error = false, message = exception.Message, tip = "系统出现错误，请联系管理员" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                filterContext.ExceptionHandled = true;
            }
            catch (Exception ex)
            {
                filterContext.Exception = ex;
                base.OnException(filterContext);
            }

        }
    }
}
