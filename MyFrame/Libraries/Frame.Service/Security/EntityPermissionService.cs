using Frame.Core;
using Frame.Core.Domain.Permissions;
using Frame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Security
{
    public class EntityPermissionService : IEntityPermissionService
    {
        private readonly IWorkContext _workContext;
        private readonly IRepository<EntityPermission> _entityRepository;
        public EntityPermissionService(IWorkContext workContext,
            IRepository<EntityPermission> entityRepository)
        {
            _workContext = workContext;
            _entityRepository = entityRepository;
        }
        public bool Authorze<T>(T entity) where T : Core.Domain.BaseEntity
        {
            var roleIds = _workContext.CurrentCustomer.Roles.Select(x => x.Id).ToList();
            return _entityRepository.Table.Any(x => x.EntityName == typeof(T).Name && x.EntityId == entity.Id && roleIds.Contains(x.RoleId));
        }
    }
}
