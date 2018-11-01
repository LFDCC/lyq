using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class LogErrorMapping : EntityTypeConfiguration<LogErrorEntity>
    {
        public LogErrorMapping()
        {
            ToTable("Sys_Log_Error");
            HasKey(t => t.Id);
            Property(t => t.RequestUrl).HasMaxLength(500);
            Property(t => t.Method).HasMaxLength(10);
            Property(t => t.Client).HasMaxLength(200);
            Property(t => t.IP).HasMaxLength(20);
            Property(t => t.Query);
            Property(t => t.Form);
            Property(t => t.Message);

        }
    }
}
