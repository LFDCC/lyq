using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class LogMapping : EntityTypeConfiguration<LogEntity>
    {
        public LogMapping()
        {
            ToTable("Sys_Log");
            HasKey(t => t.Id);
            Property(t => t.ControllerName).HasMaxLength(50);
            Property(t => t.ActionName).HasMaxLength(50);
            Property(t => t.Method).HasMaxLength(10);
            Property(t => t.RequestUrl).HasMaxLength(500);
            Property(t => t.Query).HasMaxLength(200);
            Property(t => t.Form).HasMaxLength(200);
            Property(t => t.Message).HasMaxLength(1000);
        }
    }
}
