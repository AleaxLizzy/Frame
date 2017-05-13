using Frame.Core;
using Frame.Core.Domain.Users;
using Frame.Data.Cache;
using Frame.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
namespace Frame.Web.Framework
{
    public class AdminWorkContext : IWorkContext
    {
        private Customer _cachedCustomer;
        private readonly ICustomerService _customerService;
        private readonly ICacheService _cacheService;
        public AdminWorkContext(ICustomerService customerService,
            ICacheService cacheService)
        {
            _customerService = customerService;
            _cacheService = cacheService;
        }
        public Customer CurrentCustomer
        {
            get
            {
                if (_cachedCustomer != null)
                {
                    return _cachedCustomer;
                }
                _cachedCustomer = GetCustomerCookie();
                return _cachedCustomer;
            }
            set
            {
                SetCustomerCookie(value);
                _cachedCustomer = value;
            }


        }

        public void SetCustomerCookie(Customer customer)
        {
            var userData = Guid.NewGuid().ToString();
            var ticket = new FormsAuthenticationTicket(1, customer.Email, DateTime.Now, DateTime.Now.AddDays(1), true, userData);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { HttpOnly = true };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public Customer GetCustomerCookie()
        {
            var httpContext = HttpContext.Current;
            if (httpContext != null && httpContext.Request != null && httpContext.Request.IsAuthenticated && httpContext.User.Identity is FormsIdentity)
            {
                var formsIdentity = (FormsIdentity)httpContext.User.Identity;
                var userEmail = formsIdentity.Ticket.Name;
                var userData = formsIdentity.Ticket.UserData;
                if (!string.IsNullOrEmpty(userEmail))
                {
                    return _cacheService.Get("User[" + userEmail + "]", () =>
                    {
                        var customer = _customerService.GetCustomerByEmail(userEmail);
                        if (customer == null)
                        {
                            return null;
                        }
                        else
                        {
                            _cachedCustomer = customer;
                        }
                        return _cachedCustomer;
                    });
                }
            }
            return null;
        }

    }



}
