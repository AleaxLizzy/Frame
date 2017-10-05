using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Infrastructure
{
    public class ServiceContainer
    {
        #region Unity Container
        private static Lazy<IUnityContainer> UnityContainer = new Lazy<IUnityContainer>(() =>
        {
            return new UnityContainer();
        });


        public static IUnityContainer Current { get { return UnityContainer.Value; } }
        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        /// 
        public T Resolve<T>() where T : class
        {
            return Current.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return Current.ResolveAll<T>();
        }
        #endregion

    }
}
