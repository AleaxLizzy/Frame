using Frame.Core;
using Frame.Core.Infrastructure;
using Frame.Service.PermissionProvider;
using Frame.Service.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.InitializationTask
{
    public class InitPermission : IStartupTask
    {
        public int Order
        {
            get { return 0; }

        }

        public void Execute()
        {
            var permissionProvider=EngineContext.Current.Resolve<IPermissionService>();
            permissionProvider.InstallPermissions();
        }
    }
}
