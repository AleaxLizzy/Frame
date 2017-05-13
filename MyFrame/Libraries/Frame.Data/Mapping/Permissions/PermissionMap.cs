using Frame.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Mapping.Permissions
{
    public class PermissionMap : EntityTypeConfiguration<Permission>
    {
        public PermissionMap()
        {
            this.HasKey(x=>x.Id);
            this.Property(x=>x.Name).IsRequired().HasMaxLength(100);
            this.Property(x => x.Category).IsRequired().HasMaxLength(100);
        }
    }
}
