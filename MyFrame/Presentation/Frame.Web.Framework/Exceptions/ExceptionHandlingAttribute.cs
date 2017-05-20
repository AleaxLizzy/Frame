using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace Frame.Web.Framework.Exceptions
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public string ExceptionPolicyName { get; private set; }

        public ExceptionHandlingAttribute(string ExceptionPolicyName = "defaultPolicy")
        {
            this.ExceptionPolicyName = ExceptionPolicyName;
        }
        public override void OnException(ExceptionContext filterContext)
        {
            try
            {
                ExceptionPolicy.HandleException(filterContext.Exception, ExceptionPolicyName);
            }
            catch (Exception ex)
            {
                filterContext.Exception = ex;
                base.OnException(filterContext);
            }
          
        }
    }
}
