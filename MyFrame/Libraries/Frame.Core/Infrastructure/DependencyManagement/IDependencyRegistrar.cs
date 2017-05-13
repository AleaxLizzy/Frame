using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(IUnityContainer container);

    }
}
