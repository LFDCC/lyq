using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class MenuMapping : EntityTypeConfiguration<MenuEntity>
    {
        public MenuMapping()
        {
            ToTable("Sys_Menu");
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);//主键id设置不自动增长
            Property(t => t.Title).HasMaxLength(50).IsRequired();
            Property(t => t.Url).HasMaxLength(50);
            Property(t => t.Icon).HasMaxLength(50);
        }
    }
}
