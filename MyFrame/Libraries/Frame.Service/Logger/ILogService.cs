using Frame.Core.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Logger
{
    public interface ILogService
    {
        void Add(Log entity);
    }
}
