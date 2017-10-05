using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frame.Service.Scheduler
{
    public class DefaultDateService : IDateService
    {
        public DateTime GetNowDateTime()
        {
            return DateTime.Now;
        }
    }
}