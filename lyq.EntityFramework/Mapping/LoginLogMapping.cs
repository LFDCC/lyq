using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class LoginLogMapping : EntityTypeConfiguration<LoginLogEntity>
    {
        public LoginLogMapping()
        {
            ToTable("Sys_Log_Login");
            HasKey(t => t.Id);
            Property(t => t.LoginName).HasMaxLength(50);
            Property(t => t.ClientName).HasMaxLength(100);
            Property(t => t.ClientIP).HasMaxLength(20);

        }
    }
}
