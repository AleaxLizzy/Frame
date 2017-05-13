using Frame.Core.Infrastructure.DependencyManagement;
using Frame.Service.Navigates;
using Frame.Service.PermissionProvider;
using Frame.Service.Permissions;
using Frame.Service.Security;
using Frame.Service.Users;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service
{
    public class ServiceDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IPermissionService,PermissionService>();
            container.RegisterType<IPermissionProvider, AdminPermissionProvider>("AdminPermission");
            container.RegisterType<IPermissionProvider, WebPermissionProvider>("WebPermission");
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<INavigateService, NavigateService>();
            container.RegisterType<IEntityPermissionService, EntityPermissionService>();

        }
    }
}
