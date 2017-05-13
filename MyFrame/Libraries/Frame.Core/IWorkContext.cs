using Frame.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core
{
    public interface IWorkContext
    {
        Customer CurrentCustomer { get; set; }
    }
}
