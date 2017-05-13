using Frame.Core;
using Frame.Core.Infrastructure.DependencyManagement;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Web.Framework.Infrastructure
{
    class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(IUnityContainer container)
        {
           container.RegisterType<IWorkContext,AdminWorkContext>();
        }
    }
}
