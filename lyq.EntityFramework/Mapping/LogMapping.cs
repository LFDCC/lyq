using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class LogMapping:EntityTypeConfiguration<LogEntity>
    {
        public LogMapping() {
            ToTable("Sys_Log");
            Property(t => t.ServiceName).HasMaxLength(50);
            Property(t => t.MethodName).HasMaxLength(50);
            Property(t => t.Parameters).HasMaxLength(50);
        }
    }
}
