using Frame.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Models.Role.CndModel
{
    public class RoleCndModel : ConditionModelBase
    {
        public string Name { get; set; }

        public RoleTypeEnum? Type { get; set; }

        public bool? Active { get;set; }
    }
}
