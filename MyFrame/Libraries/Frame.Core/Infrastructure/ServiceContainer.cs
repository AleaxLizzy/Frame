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
        #endregion

    }
}
