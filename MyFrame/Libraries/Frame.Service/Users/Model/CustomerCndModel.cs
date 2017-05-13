using Frame.Core.Domain.Users;
using Frame.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Users.Model
{
    public class CustomerCndModel : ConditionModelBase
    {
        public string Name { get; set; }
        public bool? Active { get; set; }

        public string Email { get; set; }

        public CustomerTypeEnum? Type { get; set; }
    }
}
