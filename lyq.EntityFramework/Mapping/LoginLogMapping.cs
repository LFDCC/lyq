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
            HasIndex(t => t.UserName);
            Property(t => t.UserName).HasMaxLength(50);
            Property(t => t.ClientName).HasMaxLength(200);
            Property(t => t.ClientIP).HasMaxLength(20);
            Property(t => t.Message).HasMaxLength(20);

        }
    }
}
