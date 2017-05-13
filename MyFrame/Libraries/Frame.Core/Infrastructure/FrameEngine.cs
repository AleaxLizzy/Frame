using Frame.Core.Infrastructure.DependencyManagement;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frame.Util;
namespace Frame.Core.Infrastructure
{
    public class FrameEngine : IEngine
    {
        private IUnityContainer _container;
        public FrameEngine()
        {
            _container = ServiceContainer.Current;
        }

        public void Initialize()
        {
            _container.RegisterInstance<IUnityContainer>(_container);
            var typeFinder = CreateTypeFinder();
            _container.RegisterInstance<ITypeFinder>(typeFinder);
            var registerTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            foreach (Type registerType in registerTypes)
            {
                var register = (IDependencyRegistrar)Activator.CreateInstance(registerType);
                register.Register(_container);
            }
            if (ConfigurationManager.AppSettings["Frame:IgnoreStartupTasks"].ToBool())
            {
                //RunStartupTasks();
            }
        }

        public ITypeFinder CreateTypeFinder()
        {
            return new WebAppTypeFinder();
        }
        public void RunStartupTasks()
        {

            var typeFinder = _container.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks =startUpTaskTypes.Select(startUpTaskType => (IStartupTask)Activator.CreateInstance(startUpTaskType)).ToList();
            //sort
            startUpTasks = startUpTasks.AsQueryable().OrderBy(st => st.Order).ToList();
            foreach (var startUpTask in startUpTasks)
                startUpTask.Execute();
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return _container.ResolveAll<T>();
        }
    }
}
