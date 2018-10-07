using lyq.Entities;
using System.Data.Entity.ModelConfiguration;

namespace lyq.EntityFramework.Mapping
{
    public class RoleMapping : EntityTypeConfiguration<RoleEntity>
    {
        public RoleMapping()
        {
            ToTable("Sys_Role");
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);//主键不自增            
        }
    }
}
