using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class ConfiguracionMap : EntityTypeConfiguration<Configuracion>
    {
        public ConfiguracionMap()
        {
            // Primary Key
            this.HasKey(t => t.ConfiguracionId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Configuracion");
            this.Property(t => t.ConfiguracionId).HasColumnName("ConfiguracionId");
            this.Property(t => t.CantidadEmpleado).HasColumnName("CantidadEmpleado");
        }
    }
}
