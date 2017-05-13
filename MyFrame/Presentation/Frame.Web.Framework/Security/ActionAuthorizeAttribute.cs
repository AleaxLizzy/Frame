using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Configuration;
using Frame.Core.Infrastructure;
using Frame.Service.Permissions;
namespace Frame.Web.Framework.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ActionAuthorizeAttribute : AuthorizeAttribute
    {
        public string[] PermissionNames { get; private set; }

        public ActionAuthorizeAttribute(params string[] permissionNames)
        {
            this.PermissionNames = permissionNames ?? new string[0];
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            List<string> actionPermissionNames = PermissionNames.ToList();
            var systemName = ConfigurationManager.AppSettings["Frame:SystemFlag"];
            if (actionPermissionNames.Any())
            {
                actionPermissionNames = actionPermissionNames.Select(x => systemName + x).ToList();
            }
            actionPermissionNames.Add(systemName + controllerName + actionName);
            if (actionPermissionNames.Any(x => permissionService.Authorize(x)))
            {
                return;
            }

            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

    }

}
