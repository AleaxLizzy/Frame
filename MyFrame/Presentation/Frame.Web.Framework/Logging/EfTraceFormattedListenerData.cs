using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using System.Configuration;
using System.Diagnostics;
namespace Frame.Web.Framework.Logging
{
    public class EfTraceFormattedListenerData : TraceListenerData
    {
        private const string formatterNameProperty = "formatter";

        [ConfigurationProperty(formatterNameProperty, IsRequired = false)]
        public string Formatter
        {
            get { return (string)base[formatterNameProperty]; }
            set { base[formatterNameProperty] = value; }
        }

        protected override TraceListener CoreBuildTraceListener(LoggingSettings settings)
        {
            var formatter = this.BuildFormatterSafe(settings, this.Formatter);
            return new EfTraceFormattedListener(formatter);
        }
    }
}
