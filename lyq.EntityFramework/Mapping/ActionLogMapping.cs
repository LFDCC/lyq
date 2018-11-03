using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class ActionLogMapping : EntityTypeConfiguration<ActionLogEntity>
    {
        public ActionLogMapping()
        {
            ToTable("Sys_Log_Action");
            HasKey(t => t.Id);
            Property(t => t.RequestUrl).HasMaxLength(500);
            Property(t => t.Method).HasMaxLength(10);
            Property(t => t.ClientName).HasMaxLength(100);
            Property(t => t.ClientIP).HasMaxLength(20);
            Property(t => t.Query);
            Property(t => t.Form);

        }
    }
}
