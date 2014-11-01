using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class RolMap : EntityTypeConfiguration<Rol>
    {
        public RolMap()
        {
            // Primary Key
            this.HasKey(t => t.RolId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Rol");
            this.Property(t => t.RolId).HasColumnName("RolId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
