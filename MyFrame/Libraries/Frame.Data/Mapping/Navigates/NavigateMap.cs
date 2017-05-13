using Frame.Core.Domain.Navigates;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Mapping.Navigates
{
    public class NavigateMap : EntityTypeConfiguration<Navigate>
    {
        public NavigateMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).HasMaxLength(20).IsRequired();
            this.Property(x => x.Controller).HasMaxLength(20).IsOptional();
            this.Property(x => x.Action).HasMaxLength(20).IsOptional();
            this.Property(x => x.Icon).HasMaxLength(50).IsRequired();
            this.HasOptional(x => x.Parent);
        }
    }
}
