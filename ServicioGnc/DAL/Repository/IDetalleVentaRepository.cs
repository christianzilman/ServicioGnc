using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioGnc.DAL.Repository
{
    public interface IDetalleVentaRepository:IGenericRepository<DetalleVenta>
    {
        List<DetalleVenta> GetByProductoIdEstadoId(int productoId,int estadoId);

        List<DetalleVenta> GetByProductoIdEstadoIdFechaDesdeFechaHasta(int productoId, int estadoId, DateTime fechaDesde, DateTime fechaHasta);

        List<DetalleVenta> GetByVenta(int ventaId);
    }
}
