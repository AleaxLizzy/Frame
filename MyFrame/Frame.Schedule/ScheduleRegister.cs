using Frame.Core.Infrastructure;
using Frame.Core.Infrastructure.DependencyManagement;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Schedule
{
    public class ScheduleRegister : IDependencyRegistrar
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<ISchedulerProvider, QuartzSchedulerProvider>("Quartz");
        }
    }
}
