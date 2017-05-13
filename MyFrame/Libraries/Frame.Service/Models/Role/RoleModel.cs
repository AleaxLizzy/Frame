using Frame.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Models.Role
{
    public class RoleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SystemName { get; set; }

        public bool Active { get; set; }

        public int? ParentId { get; set; }


        public RoleTypeEnum Type { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
