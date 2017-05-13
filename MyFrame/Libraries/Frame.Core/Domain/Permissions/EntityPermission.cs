using Frame.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Domain.Permissions
{
   public class EntityPermission:BaseEntity
    {
        public int EntityId { get; set; }

        public string EntityName { get; set; }

        public int RoleId { get; set; }

       [DefaultValue(false)]
        public bool Active { get; set; }

       public virtual Role Role { get; set; }
    }
}
