using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Scheduler
{
    public interface IDateService
    {
        DateTime GetNowDateTime();
    }
}
