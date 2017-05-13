using Frame.Core.Infrastructure.DependencyManagement;
using Frame.Data.Cache;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data
{
    public class DataDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));
            container.RegisterType<IDbContext, FrameDbContext>();
            container.RegisterType<ICacheService, MemoryCacheService>();
        }
    }
}
