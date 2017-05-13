using Frame.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.PermissionProvider
{
    public class DefaultPermissionRecord
    {
        public DefaultPermissionRecord()
        {
            this.Permissions = new List<Permission>();
        }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string RoleSystemName { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the permissions
        /// </summary>
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
