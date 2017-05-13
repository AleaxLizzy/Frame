using Frame.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Security
{
    public interface IEntityPermissionService
    {
        bool Authorze<T>(T entity) where T : BaseEntity;
    }
}
