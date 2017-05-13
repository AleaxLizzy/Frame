using Frame.Core.Domain.Users;
using Frame.Data;
using Frame.Service.Models.Role;
using Frame.Service.Models.Role.CndModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using Frame.Service.Permissions;
using Frame.Core.Domain.Permissions;
namespace Frame.Service.Users
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IDbContext _dbContext;
        public RoleService(IRepository<Role> roleRepository,
            IRepository<Permission> permissionRepository,
            IDbContext dbContext
            )
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _dbContext = dbContext;
        }
        public Role GetSuperRole()
        {
            return _roleRepository.Table.FirstOrDefault(x => x.Type == RoleTypeEnum.SuperAdminRole);
        }


        public Role GetRoleBySystemName(string systemName)
        {
            return _roleRepository.Table.FirstOrDefault(x => x.SystemName == systemName);
        }


        public IPagedList<RoleModel> GetRoles(RoleCndModel cnd)
        {
            var query = from x in _roleRepository.Table.Where(x => x.Type != RoleTypeEnum.SuperAdminRole)
                        select new RoleModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Active = x.Active,
                            ParentId = x.ParentId,
                            CreatedTime = x.CreatedTime,
                            Type = x.Type
                        };
            if (cnd.Id > 0)
            {
                query = query.Where(x => x.Id == cnd.Id);
            }
            if (!string.IsNullOrEmpty(cnd.Name))
            {
                query = query.Where(x => x.Name == cnd.Name);
            }
            if (cnd.Type.HasValue)
            {
                query = query.Where(x => x.Type == cnd.Type.Value);
            }
            if (cnd.Active.HasValue)
            {
                query = query.Where(x => x.Active == cnd.Active.Value);
            }
            if (cnd.Start.HasValue)
            {
                var start = cnd.Start.Value.Date;
                query = query.Where(x => x.CreatedTime >= start);
            }
            if (cnd.End.HasValue)
            {
                query = query.Where(x => x.CreatedTime < cnd.End);
            }
            return new PagedList<RoleModel>(query.OrderByDescending(x => x.Id), cnd.PageIndex, cnd.PageSize);
        }


        public int Delete(List<int> ids)
        {
            return _roleRepository.Delete(x => ids.Contains(x.Id));
        }


        public RoleModel GetModel(int id)
        {
            var query = from x in _roleRepository.Table.Where(x => x.Id == id)
                        select new RoleModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Active = x.Active,
                            ParentId = x.ParentId,
                            CreatedTime = x.CreatedTime,
                            Type = x.Type,
                            SystemName = x.SystemName
                        };
            return query.FirstOrDefault();
        }


        public int AddOrUpdate(RoleModel model)
        {
            if (model.Id > 0)
            {
                var entity = _roleRepository.Table.FirstOrDefault(x => x.Id == model.Id);
                entity.Name = model.Name;
                entity.Active = model.Active;
                entity.Type = model.Type;
                entity.ModifyTime = DateTime.Now;
                entity.SystemName = model.SystemName;
                return _roleRepository.Update(entity);
            }
            else
            {
                var entity = new Role
                {
                    Name = model.Name,
                    Active = model.Active,
                    Type = model.Type,
                    CreatedTime = DateTime.Now,
                    SystemName = model.SystemName,
                    ParentId = model.ParentId.HasValue ? model.ParentId.Value : 0
                };
                return _roleRepository.Insert(entity);
            }

        }

        public bool ExistName(string name, int id)
        {
            return _roleRepository.Table.Any(x => x.Name == name && x.Id != id);
        }

        public bool ExisSystemName(string name, int id)
        {
            return _roleRepository.Table.Any(x => x.SystemName == name && x.Id != id);
        }


        public Role GetRole(int id)
        {
            return _roleRepository.Get(id);
        }


        public bool Update(int id, List<int> permissionIds)
        {
            var role = _dbContext.Set<Role>().FirstOrDefault(x => x.Id == id);
            //新增权限
            permissionIds.ToList().ForEach(x =>
            {
                if (!role.Permissions.Any(y => y.Id == x))
                {
                    var permission = _dbContext.Set<Permission>().FirstOrDefault(z => z.Id == x);
                    role.Permissions.Add(permission);
                }
            });

            //删除权限
            role.Permissions.OrderBy(x => x.Id).ToList().ForEach(x =>
            {
                if (!permissionIds.Any(z => z == x.Id))
                {
                    role.Permissions.Remove(x);
                }
            });
            _dbContext.SaveChangesAsync();
            return true;


        }


        public IList<Role> Roles(RoleTypeEnum type = RoleTypeEnum.AdminRole)
        {
            return _roleRepository.Table.Where(x => x.Active == true && x.Type == type).ToList();
        }
    }
}
