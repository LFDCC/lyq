using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class LogOperMapping : EntityTypeConfiguration<LogOperEntity>
    {
        public LogOperMapping()
        {
            ToTable("Sys_Log_Operation");
            HasKey(t => t.Id);
            Property(t => t.RequestUrl).HasMaxLength(500);
            Property(t => t.Method).HasMaxLength(10);
            Property(t => t.Client).HasMaxLength(100);
            Property(t => t.IP).HasMaxLength(20);
            Property(t => t.Query);
            Property(t => t.Form);
            Property(t => t.Message);

        }
    }
}
