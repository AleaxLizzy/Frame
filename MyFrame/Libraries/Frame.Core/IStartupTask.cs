using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core
{
   public interface IStartupTask
    {
       int Order { get;}

       void Execute();
    }
}
