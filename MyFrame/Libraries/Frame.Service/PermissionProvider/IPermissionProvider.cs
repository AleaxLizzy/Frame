using Frame.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.PermissionProvider
{
    public interface IPermissionProvider
    {
        IEnumerable<Permission> GetPermissions();

        IEnumerable<DefaultPermissionRecord> GetDefaultPermission();
    }
}
