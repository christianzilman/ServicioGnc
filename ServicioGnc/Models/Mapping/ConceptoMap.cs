using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class ConceptoMap : EntityTypeConfiguration<Concepto>
    {
        public ConceptoMap()
        {
            // Primary Key
            this.HasKey(t => t.ConceptoId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Concepto");
            this.Property(t => t.ConceptoId).HasColumnName("ConceptoId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Porcentaje).HasColumnName("Porcentaje");
            this.Property(t => t.Importe).HasColumnName("Importe");
            this.Property(t => t.Utilidad).HasColumnName("Utilidad");
            this.Property(t => t.TipoConceptoId).HasColumnName("TipoConceptoId");

            // Relationships
            this.HasOptional(t => t.TipoConcepto)
                .WithMany(t => t.Conceptoes)
                .HasForeignKey(d => d.TipoConceptoId);

        }
    }
}
