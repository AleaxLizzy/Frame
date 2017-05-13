using Frame.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Mapping.Permissions
{
    public class EntityPermissionMap : EntityTypeConfiguration<EntityPermission>
    {
        public EntityPermissionMap()
        {
            this.HasKey(x => new { x.EntityId, x.RoleId, x.EntityName });
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(x => x.Role).WithMany().HasForeignKey(t=>t.RoleId).WillCascadeOnDelete(true);
        }
    }
}
