using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class DetalleCompraRepository:GenericRepository<ServicioGncContext,DetalleCompra>,IDetalleCompraRepository
    {
        public DetalleCompraRepository(){
        }
        public DetalleCompraRepository(ServicioGncContext context){
            this.Context = context;
        }

        public List<DetalleCompra> GetByProductoIdEstadoId(int productoId, int estadoId)
        {            
            return this.Context.Set<DetalleCompra>().Where(c=>c.Compra.TipoEstadoId == estadoId && c.ProductoId == productoId).ToList();            
        }


        public List<DetalleCompra> GetByProductoIdEstadoIdFechaDesdeFechaHasta(int productoId, int estadoId, DateTime fechaDesde, DateTime fechaHasta)
        {
            return this.Context.Set<DetalleCompra>().Where(c => c.Compra.TipoEstadoId == estadoId && c.ProductoId == productoId && c.Compra.Fecha >= fechaDesde && c.Compra.Fecha <= fechaHasta).ToList();            
        }
    }
}