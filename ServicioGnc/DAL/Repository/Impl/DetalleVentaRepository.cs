using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class DetalleVentaRepository:GenericRepository<ServicioGncContext,DetalleVenta>,IDetalleVentaRepository
    {
        public DetalleVentaRepository() { }
        public DetalleVentaRepository(ServicioGncContext context) {
            this.Context = context;
        }

        public List<DetalleVenta> GetByProductoIdEstadoId(int productoId, int estadoId)
        {
            return this.Context.Set<DetalleVenta>().Where(v=>v.Venta.TipoEstadoId == estadoId && v.ProductoId == productoId).ToList();
        }



        public List<DetalleVenta> GetByProductoIdEstadoIdFechaDesdeFechaHasta(int productoId, int estadoId, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<DetalleVenta> listDetalleVenta = new List<DetalleVenta>();
            if(productoId==null){
                productoId = 0;
            }
            if(fechaDesde!=null && fechaHasta !=null){
                listDetalleVenta = this.Context.Set<DetalleVenta>().Where(v => v.Venta.TipoEstadoId == estadoId && v.ProductoId == productoId && v.Venta.Fecha >= fechaDesde && v.Venta.Fecha <= fechaHasta).ToList();
            }else{
                listDetalleVenta =  this.Context.Set<DetalleVenta>().Where(v => v.Venta.TipoEstadoId == estadoId && v.ProductoId == productoId).ToList();
            }
            return listDetalleVenta;
        }

        public List<DetalleVenta> GetByVenta(int ventaId)
        {
            return this.Context.Set<DetalleVenta>().Where(c => c.VentaId == ventaId).ToList();
        }
    }
}