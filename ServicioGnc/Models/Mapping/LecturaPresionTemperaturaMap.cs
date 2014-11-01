using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class LecturaPresionTemperaturaMap : EntityTypeConfiguration<LecturaPresionTemperatura>
    {
        public LecturaPresionTemperaturaMap()
        {
            // Primary Key
            this.HasKey(t => t.LecturaPresionTemperaturaId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("LecturaPresionTemperatura");
            this.Property(t => t.LecturaPresionTemperaturaId).HasColumnName("LecturaPresionTemperaturaId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Presion).HasColumnName("Presion");
            this.Property(t => t.Temperatura).HasColumnName("Temperatura");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
        }
    }
}
