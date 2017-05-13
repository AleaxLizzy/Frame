using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Infrastructure
{
    public interface IEngine
    {
        /// <summary>
        ///     Initialize components and plugins in the nop environment.
        /// </summary>
        void Initialize();

        T Resolve<T>() where T : class;

        IEnumerable<T> ResolveAll<T>() where T : class;
    }
}
