using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class PostMapping : EntityTypeConfiguration<PostEntity>
    {
        public PostMapping()
        {
            ToTable("Sys_Post");
            HasKey(t => t.Id);
            HasIndex(t => t.CreateUserId);
            HasRequired(t => t.User).WithMany().HasForeignKey(t => t.CreateUserId);
            Property(t => t.Email).HasMaxLength(50).IsRequired();
            Property(t => t.Title).HasMaxLength(100).IsRequired();
            Property(t => t.Content).HasMaxLength(1000).IsRequired();            
        }
    }
}
