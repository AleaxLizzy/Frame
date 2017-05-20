﻿using Frame.Web.Framework.Exceptions;
using System.Web;
using System.Web.Mvc;

namespace Frame.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionHandlingAttribute());
        }
    }
}
