using Frame.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.PermissionProvider
{
    public class AdminPermissionProvider : IPermissionProvider
    {
        public IEnumerable<Permission> GetPermissions()
        {
            return new []
            {
                 AccessAdminPanel,
                 RoleList,
                 RoleDelete,
                 RoleCreate,
                 RoleGrant,

                 CustomerList,
                 CustomerCreate,
                 CustomerDelete,
                 CustomerGrant,

                 NavigateManage
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
                        AccessAdminPanel,
                        RoleList
                    }
                }
            };
        }

        public static readonly Permission AccessAdminPanel = new Permission { Name = "主页", SystemName = "HomeIndex", Category = "控制面板", Description = "后台首页" };
        public static readonly Permission RoleList = new Permission { Name = "查询", SystemName = "RoleRoleList", Category = "角色管理", Description = "后台角色管理" };
        public static readonly Permission RoleDelete = new Permission { Name = "删除", SystemName = "RoleDelete", Category = "角色管理", Description = "后台角色管理" };
        public static readonly Permission RoleCreate = new Permission { Name = "添加/编辑", SystemName = "RoleCreate", Category = "角色管理", Description = "后台角色管理" };
        public static readonly Permission RoleGrant = new Permission { Name = "授权", SystemName = "RoleGrant", Category = "角色管理", Description = "后台角色管理" };

        public static readonly Permission CustomerList = new Permission { Name = "查询", SystemName = "CustomerList", Category = "用户管理", Description = "后台用户管理" };
        public static readonly Permission CustomerCreate = new Permission { Name = "添加/编辑", SystemName = "CustomerCreate", Category = "用户管理", Description = "后台用户管理" };
        public static readonly Permission CustomerDelete = new Permission { Name = "删除", SystemName = "CustomerDelete", Category = "用户管理", Description = "后台用户管理" };
        public static readonly Permission CustomerGrant = new Permission { Name = "授权", SystemName = "CustomerGrant", Category = "用户管理", Description = "后台用户管理" };


        public static readonly Permission NavigateManage = new Permission { Name = "查询", SystemName = "NavigateList", Category = "菜单管理", Description = "菜单管理" };


    }
}
