using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class TipoConceptoMap : EntityTypeConfiguration<TipoConcepto>
    {
        public TipoConceptoMap()
        {
            // Primary Key
            this.HasKey(t => t.TipoConceptoId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("TipoConcepto");
            this.Property(t => t.TipoConceptoId).HasColumnName("TipoConceptoId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
