using Frame.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.PermissionProvider
{
    public class WebPermissionProvider : IPermissionProvider
    {
        public IEnumerable<Permission> GetPermissions()
        {
            return new[] 
            { 
              AccessAdminPanel
            };
        }


        public IEnumerable<DefaultPermissionRecord> GetDefaultPermission()
        {
            return new[] 
            { 
                new DefaultPermissionRecord
                {
                    RoleSystemName="",
                    Permissions=new []
                    {
                        AccessAdminPanel
                    }
                }
            };
        }

        public static readonly Permission AccessAdminPanel = new Permission { Name = "主页", SystemName = "HomeIndex", Category = "控制面板", Description = "后台首页" };
    }
}
