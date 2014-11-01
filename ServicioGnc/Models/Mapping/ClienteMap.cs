using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            this.HasKey(t => t.ClienteId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(150);

            this.Property(t => t.Domicilio)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Cliente");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Domicilio).HasColumnName("Domicilio");
        }
    }
}
