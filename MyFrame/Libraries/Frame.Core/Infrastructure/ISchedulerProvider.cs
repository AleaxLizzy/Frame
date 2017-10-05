using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Infrastructure
{
    public interface ISchedulerProvider
    {
        void Start();

        void Dispose();
    }
}
