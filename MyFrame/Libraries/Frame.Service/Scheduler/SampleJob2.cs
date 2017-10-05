using Quartz;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Scheduler
{
    public class SampleJob2 : IJob
    {
        private readonly IDateService _dateService;
        public SampleJob2(IDateService dateService)
        {
            _dateService = dateService;
        }
        public Task Execute(IJobExecutionContext context)
        {
            System.Diagnostics.Debug.WriteLine("Name=SampleJob2,Date={0}", _dateService.GetNowDateTime());
            return Task.FromResult(0);
        }
    }
}
