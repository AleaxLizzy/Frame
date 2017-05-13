using Frame.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Mapping.Customers
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).HasMaxLength(20).IsRequired();
            this.Property(x => x.PassWord).HasMaxLength(128).IsRequired();
            this.Property(x => x.Email).HasMaxLength(30).IsRequired();
            this.HasMany(x => x.Roles).WithMany().Map(y =>
            {
                y.ToTable("CustomerRole");
                y.MapLeftKey("CustomerId");
                y.MapRightKey("RoleId");
            });
        }
    }
}
