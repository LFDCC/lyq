using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class ErrorLogMapping : EntityTypeConfiguration<ErrorLogEntity>
    {
        public ErrorLogMapping()
        {
            ToTable("Sys_Log_Error");
            HasKey(t => t.Id);
            Property(t => t.RequestUrl).HasMaxLength(500);
            Property(t => t.Method).HasMaxLength(10);
            Property(t => t.ClientName).HasMaxLength(200);
            Property(t => t.ClientIP).HasMaxLength(20);
            Property(t => t.Query).HasMaxLength(1000);
            Property(t => t.Form).HasMaxLength(1000);
            Property(t => t.Message).HasMaxLength(2000) ;

        }
    }
}
