using Frame.Core;
using Frame.Core.Domain.Permissions;
using Frame.Core.Domain.Users;
using Frame.Core.Infrastructure;
using Frame.Data;
using Frame.Service.PermissionProvider;
using Frame.Service.Permissions.Models;
using Frame.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IDbContext _dbContext;
        private readonly IRoleService _roleService;
        private readonly IWorkContext _workContext;
        public PermissionService(IRepository<Permission> permissionRepository,
            IDbContext dbContext,
            RoleService roleService,
            IWorkContext workContext)
        {
            _permissionRepository = permissionRepository;
            _dbContext = dbContext;
            _roleService = roleService;
            _workContext = workContext;
        }

        /// <summary>
        /// 权限初始化
        /// 先忽略其他系统账户默认权限
        /// </summary>
        public void InstallPermissions()
        {
            var permissionProdivers = EngineContext.Current.ResolveAll<IPermissionProvider>();
            var superAdminRole = _dbContext.Set<Role>().FirstOrDefault(x => x.Type == RoleTypeEnum.SuperAdminRole);
            foreach (var provider in permissionProdivers)
            {
                var systemName = provider.GetType().Name.Replace("PermissionProvider", "");
                var permissions = provider.GetPermissions();
                var permissionNames = permissions.Select(x => systemName + x.SystemName).ToList();
                var permissionEntities = GetPrimissionsBysSystemName(systemName).ToList();
                foreach (var permissionItem in permissions)
                {
                    var entity = permissionEntities.FirstOrDefault(x => x.SystemName == systemName + permissionItem.SystemName);
                    if (entity != null)
                    {
                        entity.ModifyTime = DateTime.Now;
                        entity.Category = permissionItem.Category;
                        entity.Name = permissionItem.Name;
                        entity.Description = permissionItem.Description;
                        if (systemName == "Admin")
                        {
                            if(!superAdminRole.Permissions.Any(x=>x.Id==entity.Id))
                            {
                                superAdminRole.Permissions.Add(entity);
                            }
                        }
                    }
                    else
                    {
                        entity = new Permission
                        {
                            Name = permissionItem.Name,
                            SystemName = systemName + permissionItem.SystemName,
                            Description = permissionItem.Description,
                            Category = permissionItem.Category,
                            CreatedTime = DateTime.Now
                        };
                        if (systemName == "Admin")
                        {
                            if (entity.Id==0)
                            {
                                superAdminRole.Permissions.Add(entity);
                            }
                        }
                        else
                        {
                            entity.ModifyTime = DateTime.Now;
                            _dbContext.Set<Permission>().Add(entity);
                        }
                    }
                }
                //移除已删除权限
                foreach (var item in permissionEntities.OrderBy(x => x.Id))
                {
                    if (!permissionNames.Contains(item.SystemName))
                    {
                        _dbContext.Set<Permission>().Remove(item);
                    }
                }
            }
            _dbContext.SaveChangesAsync();
        }

        private IQueryable<Permission> GetPrimissionsBysSystemName(string systemName)
        {
            return _dbContext.Set<Permission>().Where(x => x.SystemName.StartsWith(systemName));
        }





        public bool Authorize(string permissionSystemName)
        {
            var customer = _workContext.CurrentCustomer;
            if (customer.Active)
            {
                return Authorize(permissionSystemName, customer);
            }
            return false;
        }

        public bool Authorize(string permissionSystemName, Customer customer)
        {

            return customer.Roles.Where(x => x.Active).Any(y => Authorize(permissionSystemName, y));

        }

        protected virtual bool Authorize(string permissionSystemName, Role role)
        {
            return role.Permissions.Any(x => x.SystemName.Equals(permissionSystemName, StringComparison.InvariantCultureIgnoreCase));
        }


        public IQueryable<PermissionModel> GetPsermissions(string systemName)
        {
            var query = from a in _permissionRepository.Table.Where(x => x.SystemName.StartsWith(systemName))
                        select new PermissionModel
                        {
                            Id=a.Id,
                            Name=a.Name,
                            SystemName=a.SystemName,
                            Description=a.Description,
                            Category=a.Category
                        };
            return query;
        }


        public Permission GetEntity(int id)
        {
            return _permissionRepository.Table.FirstOrDefault(x=>x.Id==id);
        }
    }
}
