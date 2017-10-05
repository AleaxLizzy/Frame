using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Scheduler
{
    public class SampleJob1 : IJob
    {
        public SampleJob1()
        {

        }
        public Task Execute(IJobExecutionContext context)
        {
            System.Diagnostics.Debug.WriteLine("Name=SampleJob1,Date={0}", DateTime.Now);
            return Task.FromResult(0);
        }
    }
}
