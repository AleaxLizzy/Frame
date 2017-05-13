using Frame.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Users.Model
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }

        public string PassWordConfirm { get; set; }

        public bool Active { get; set; }
        public int ParentId { get; set; }

        public DateTime CreatedTime { get; set; }




        public CustomerTypeEnum Type { get;set;}

        public DateTime CreateTime { get; set; }
    }
}
