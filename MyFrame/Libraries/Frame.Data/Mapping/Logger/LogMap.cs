using Frame.Core.Logs;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Mapping.Logger
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.Property(x => x.Severity).IsRequired().HasMaxLength(32);
            this.Property(x => x.Title).HasMaxLength(256);
            this.Property(x => x.MachineName).HasMaxLength(32);
            this.Property(x => x.Category).HasMaxLength(64).IsRequired();
            this.Property(x => x.AppDomainName).HasMaxLength(512);
            this.Property(x => x.ProcessId).HasMaxLength(256);
            this.Property(x => x.ProcessName).HasMaxLength(512);
            this.Property(x => x.ThreadId).HasMaxLength(128);
            this.Property(x => x.Message).HasMaxLength(30000);
            this.Property(x => x.FormattedMessage).HasColumnType("ntext");
        }
    }
}
