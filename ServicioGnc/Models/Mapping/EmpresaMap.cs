using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpresaId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(50);

            this.Property(t => t.Cuit)
                .HasMaxLength(13);

            // Table & Column Mappings
            this.ToTable("Empresa");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Cuit).HasColumnName("Cuit");
        }
    }
}
