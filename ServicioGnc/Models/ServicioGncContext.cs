using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ServicioGnc.Models.Mapping;

namespace ServicioGnc.Models
{
    public partial class ServicioGncContext : DbContext
    {
        static ServicioGncContext()
        {
            Database.SetInitializer<ServicioGncContext>(null);
        }

        public ServicioGncContext()
            : base("Name=ServicioGncContext")
        {
        }

        public DbSet<AsignacionTurno> AsignacionTurnoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Concepto> Conceptoes { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<DetalleLiquidacion> DetalleLiquidacions { get; set; }
        public DbSet<DetalleTurno> DetalleTurnoes { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fichada> Fichadas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<LecturaPresionTemperatura> LecturaPresionTemperaturas { get; set; }
        public DbSet<Liquidacion> Liquidacions { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Producto> Productoes { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TipoConcepto> TipoConceptoes { get; set; }
        public DbSet<Turno> Turnoes { get; set; }
        public DbSet<Unidad> Unidads { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AsignacionTurnoMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new CompraMap());
            modelBuilder.Configurations.Add(new ConceptoMap());
            modelBuilder.Configurations.Add(new DetalleCompraMap());
            modelBuilder.Configurations.Add(new DetalleLiquidacionMap());
            modelBuilder.Configurations.Add(new DetalleTurnoMap());
            modelBuilder.Configurations.Add(new DetalleVentaMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new FichadaMap());
            modelBuilder.Configurations.Add(new HorarioMap());
            modelBuilder.Configurations.Add(new LecturaPresionTemperaturaMap());
            modelBuilder.Configurations.Add(new LiquidacionMap());
            modelBuilder.Configurations.Add(new PersonaMap());
            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new ProveedorMap());
            modelBuilder.Configurations.Add(new RolMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TipoConceptoMap());
            modelBuilder.Configurations.Add(new TurnoMap());
            modelBuilder.Configurations.Add(new UnidadMap());
            modelBuilder.Configurations.Add(new VentaMap());
        }
    }
}
