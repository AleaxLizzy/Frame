using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Domain.Users
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Roles = new List<Role>();
        }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        [DefaultValue(0)]
        public int ParentId { get; set; }

         
        public virtual ICollection<Role> Roles { get; set; }

        public CustomerTypeEnum Type { get; set; }
    }

    public enum CustomerTypeEnum
    {
        SuperAdmin = 0,
        Admin = 1,
        Normal = 2
    }
}
