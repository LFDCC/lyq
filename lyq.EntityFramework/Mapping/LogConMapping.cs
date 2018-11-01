using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class LogConMapping : EntityTypeConfiguration<LogConEntity>
    {
        public LogConMapping()
        {
            ToTable("Sys_Log_Connection");
            HasKey(t => t.Id);
            Property(t => t.LoginName).HasMaxLength(50);
            Property(t => t.Client).HasMaxLength(100);
            Property(t => t.IP).HasMaxLength(20);
            Property(t => t.Message);

        }
    }
}
