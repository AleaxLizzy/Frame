using Frame.Core.Infrastructure;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Schedule
{
    public class QuartzSchedulerProvider : ISchedulerProvider
    {
        public void Start()
        {
            EngineContext.Current.Resolve<IScheduler>().Start();
        }

        public void Dispose()
        {
            EngineContext.Current.Resolve<IScheduler>().Shutdown();
        }
    }
}
