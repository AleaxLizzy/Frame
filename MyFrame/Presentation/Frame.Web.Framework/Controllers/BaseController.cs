using Frame.Web.Framework.Extension;
using Frame.Web.Framework.Security;
using Frame.Web.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Frame.Web.Framework.Controllers
{
    [ActionAuthorize]
    public class BaseController : Controller
    {

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new CustomsJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }
        protected virtual void InformationNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Information, message, persistForTheNextRequest);
        }

        /// <summary>
        ///     Display success notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Success, message, persistForTheNextRequest);
        }

        protected virtual void WarringNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Warring, message, persistForTheNextRequest);
        }

        /// <summary>
        ///     Display error notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Error, message, persistForTheNextRequest);
        }

        /// <summary>
        ///     Display error notification
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        /// <param name="logException">A value indicating whether exception should be logged</param>
        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true,
            bool logException = true)
        {
            //if (logException)
            //{
            //    LogException(exception);
            //}
            AddNotification(NotifyType.Error, exception.Message, persistForTheNextRequest);
        }

        /// <summary>
        ///     Display notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        public virtual void AddNotification(NotifyType type, string message, bool persistForTheNextRequest = true)
        {
            var dataKey = string.Format("htyd.notifications.{0}", type);
            if (persistForTheNextRequest)
            {
                if (TempData[dataKey] == null)
                {
                    TempData[dataKey] = new List<string>();
                }
                ((List<string>)TempData[dataKey]).Add(message);
            }
            else
            {
                if (ViewData[dataKey] == null)
                {
                    ViewData[dataKey] = new List<string>();
                }
                ((List<string>)ViewData[dataKey]).Add(message);
            }
        }
    }
}
