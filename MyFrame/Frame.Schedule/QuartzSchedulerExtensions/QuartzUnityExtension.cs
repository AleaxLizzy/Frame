using Microsoft.Practices.Unity;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.Configuration;
using Frame.Core.Infrastructure;


namespace Frame.Schedule.QuartzSchedulerExtensions
{
    public class QuartzUnityExtension : UnityContainerExtension
    {
        private readonly NameValueCollection _quartzProps;

        public QuartzUnityExtension(NameValueCollection quartzProps)
        {
            this._quartzProps = quartzProps;
        }

        protected override void Initialize()
        {
            try
            {
                var container = ServiceContainer.Current;
                var constructor = new InjectionConstructor(new UnityJobFactory(container), new InjectionParameter<NameValueCollection>(_quartzProps));
                container.RegisterType<ISchedulerFactory, UnitySchedulerFactory>(new ContainerControlledLifetimeManager(), constructor);
                container.RegisterType<IScheduler>(new InjectionFactory(c => c.Resolve<ISchedulerFactory>().GetScheduler().Result));
            }
            catch (Exception ex)
            {

            }
        }
    }
}