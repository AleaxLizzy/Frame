using Frame.Core.Domain.Permissions;
using Frame.Service.Permissions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Permissions
{
    public interface IPermissionService
    {
        void InstallPermissions();

        bool Authorize(string permissionSystemName);

        IQueryable<PermissionModel> GetPsermissions(string systemName);

        Permission GetEntity(int id);
    }
}
