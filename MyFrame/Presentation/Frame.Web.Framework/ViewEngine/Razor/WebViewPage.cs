using Frame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Web.Framework.ViewEngine.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public IWorkContext WorkContext { get; set; }
    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}
