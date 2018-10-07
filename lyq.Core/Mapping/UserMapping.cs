using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class UserMapping : EntityTypeConfiguration<UserEntity>
    {
        public UserMapping()
        {
            ToTable("Sys_User");
            HasKey(t => t.Id);
            HasIndex(t => t.UserName);
            HasRequired(t => t.RoleEntity).WithMany().HasForeignKey(t => t.RoleId);
            Property(t => t.UserName).HasMaxLength(50).IsRequired();
            Property(t => t.Password).HasMaxLength(50).IsRequired();
            Property(t => t.Email).HasMaxLength(50);
            Property(t => t.Phone).HasMaxLength(50);
            Property(t => t.RealName).HasMaxLength(50);
            Property(t => t.HeadImg).HasMaxLength(100);
        }
    }
}
