using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioGnc.DAL.Repository
{
    public interface IDetalleCompraRepository: IGenericRepository<DetalleCompra>
    {
        List<DetalleCompra> GetByProductoIdEstadoId(int productoId,int estadoId);

        List<DetalleCompra> GetByProductoIdEstadoIdFechaDesdeFechaHasta(int productoId, int estadoId, DateTime fechaDesde, DateTime fechaHasta);
    }
}
