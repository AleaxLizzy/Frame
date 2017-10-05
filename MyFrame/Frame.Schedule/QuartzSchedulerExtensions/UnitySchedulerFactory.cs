using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Core;
using System.Collections.Specialized;

namespace Frame.Schedule.QuartzSchedulerExtensions
{
    public class UnitySchedulerFactory : StdSchedulerFactory
    {
        private readonly UnityJobFactory _unityJobFactory;

        public UnitySchedulerFactory(UnityJobFactory unityJobFactory, NameValueCollection props = null)
        {
            if (null != props)
            {
                base.Initialize(props);
            }

            _unityJobFactory = unityJobFactory;
        }

        protected override IScheduler Instantiate(QuartzSchedulerResources rsrcs, QuartzScheduler scheduler)
        {
            try
            {
                scheduler.JobFactory = _unityJobFactory;
                return base.Instantiate(rsrcs, scheduler);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}