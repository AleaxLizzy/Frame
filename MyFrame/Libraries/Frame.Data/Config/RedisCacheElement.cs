using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Config
{
    public class RedisCacheElement : ConfigurationElement
    {

        private const string EnablePropertyName = "enabled";

        private const string ConnectionStringProperty = "connectionString";

        [ConfigurationProperty(EnablePropertyName, IsRequired = true)]

        public bool Enabled
        {
            get { return (bool)base[EnablePropertyName]; }
            set { base[EnablePropertyName] = value; }
        }

        [ConfigurationProperty(ConnectionStringProperty)]
        public string Connectionstring
        {
            get { return (string)base[ConnectionStringProperty]; }
            set { base[ConnectionStringProperty] = value; }
        }
    }

}
