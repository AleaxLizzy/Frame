using Frame.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Mapping.Customers
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.HasMany(x => x.Permissions).WithMany().Map(y =>
            {
                y.ToTable("RolePermission");
                y.MapLeftKey("RoleId");
                y.MapRightKey("PermissionId");
            });
        }
    }
}
