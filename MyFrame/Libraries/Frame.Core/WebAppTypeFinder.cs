using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace Frame.Core
{
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        #region Ctor

        public WebAppTypeFinder()
        {
            //EnsureBinFolderAssembliesLoaded = ConfigurationManager.AppSettings["htyd:DynamicDiscovery"].ToBool();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets wether assemblies in the bin folder of the web application should be specificly checked for beeing
        ///     loaded on application load. This is need in situations where plugins need to be loaded in the AppDomain after the
        ///     application been reloaded.
        /// </summary>
        public bool EnsureBinFolderAssembliesLoaded = false;

        #endregion

        #region Fields

        private bool _binFolderAssembliesLoaded;

        #endregion

        #region Methods

        /// <summary>
        ///     Gets a physical disk path of \Bin directory
        /// </summary>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        public virtual string GetBinDirectory()
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HttpRuntime.BinDirectory;
            }
            //not hosted. For example, run either in unit tests
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (EnsureBinFolderAssembliesLoaded && !_binFolderAssembliesLoaded)
            {
                _binFolderAssembliesLoaded = true;
                var binPath = GetBinDirectory();
                LoadMatchingAssemblies(binPath);
            }

            return base.GetAssemblies();
        }

        #endregion
    }

}
