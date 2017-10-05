using Quartz.Simpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Spi;
using Microsoft.Practices.Unity;

namespace Frame.Schedule.QuartzSchedulerExtensions
{
    public class UnityJobFactory : SimpleJobFactory
    {
        private readonly IUnityContainer container;

        public UnityJobFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            IJobDetail jobDetail = bundle.JobDetail;
            Type jobType = jobDetail.JobType;
            try
            {
                return container.Resolve(jobType) as IJob ?? base.NewJob(bundle, scheduler);
            }
            catch (Exception e)
            {
                SchedulerException se = new SchedulerException(string.Format("Problem instantiating class Error:{0}"), e);
                throw se;
            }
        }
    }
}