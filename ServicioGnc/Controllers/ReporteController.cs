using ServicioGnc.DAL;
using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioGnc.Controllers
{
    public class ReporteController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        UsersContext dbSeguridad = new UsersContext();
        //
        // GET: /Reporte/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CodigoProductoVentaCompra() {

            ViewBag.ListDescripcionProductoCompraVenta = new List<DescripcionProductoVenta>();
            return View();
        }

        public class DescripcionProductoVenta {
            public int productoId { get; set; }
            public string accion { get; set; }
            public DateTime fecha { get; set; }
            public string nombreUsuario { get; set; }
        }

        public class ParametrosBusqueda {
            public Nullable<int> codigo { get; set; }
            public Nullable<DateTime> fechaDesde { get; set; }
            public Nullable<DateTime> fechaHasta { get; set; }
        }

        [HttpPost]
        public ActionResult CodigoProductoVentaCompra(ParametrosBusqueda parametros)
        {
            List<DescripcionProductoVenta> listDescripcionProductoVenta = new List<DescripcionProductoVenta>();
            ViewBag.ListDescripcionProductoCompraVenta = listDescripcionProductoVenta;

            if(ModelState.IsValid){

                int codigo = (int)parametros.codigo;
                List<DetalleVenta> listDetalleVenta = unitOfWork.DetalleVentaRepository.GetByProductoIdEstadoId(codigo, 4);

                foreach (DetalleVenta detalleVenta in listDetalleVenta)
                {
                    DescripcionProductoVenta descripcionP = new DescripcionProductoVenta();
                    descripcionP.productoId = (int)detalleVenta.ProductoId;
                    descripcionP.fecha = (DateTime)detalleVenta.Venta.Fecha;
                    descripcionP.accion = "ALTA DE VENTA";
                    descripcionP.nombreUsuario = dbSeguridad.UserProfiles.Where(u => u.UserId == detalleVenta.Venta.UsuarioId).FirstOrDefault().UserName;
                    listDescripcionProductoVenta.Add(descripcionP);
                }

                List<DetalleCompra> listDetalleCompra = unitOfWork.DetalleCompraRepository.GetByProductoIdEstadoId(codigo, 1);

                foreach (DetalleCompra detalleCompra in listDetalleCompra)
                {
                    DescripcionProductoVenta descripcionP = new DescripcionProductoVenta();
                    descripcionP.productoId = (int)detalleCompra.ProductoId;
                    descripcionP.fecha = (DateTime)detalleCompra.Compra.Fecha;
                    descripcionP.accion = "ALTA DE PEDIDO";
                    descripcionP.nombreUsuario = dbSeguridad.UserProfiles.Where(u => u.UserId == detalleCompra.Compra.UsuarioId).FirstOrDefault().UserName;
                    listDescripcionProductoVenta.Add(descripcionP);
                }

                listDetalleCompra = unitOfWork.DetalleCompraRepository.GetByProductoIdEstadoId(codigo, 2);

                foreach (DetalleCompra detalleCompra in listDetalleCompra)
                {
                    DescripcionProductoVenta descripcionP = new DescripcionProductoVenta();
                    descripcionP.productoId = (int)detalleCompra.ProductoId;
                    descripcionP.fecha = (DateTime)detalleCompra.Compra.Fecha;
                    descripcionP.accion = "ALTA DE COMPRA";
                    descripcionP.nombreUsuario = dbSeguridad.UserProfiles.Where(u => u.UserId == detalleCompra.Compra.UsuarioId).FirstOrDefault().UserName;
                    listDescripcionProductoVenta.Add(descripcionP);
                }

                ViewBag.ListDescripcionProductoCompraVenta = listDescripcionProductoVenta;
            }
            return View();
        }

        public void InicializarParametrosReporteCodigoPeriodoVentaCompra(){
            ViewBag.CantidadPedida = "";
            ViewBag.CantidadComprada = "";
            ViewBag.CantidadVendida = "";
            ViewBag.MontoPedido = "";
            ViewBag.MontoComprado = "";
            ViewBag.MontoVendido = "";
            ViewBag.Codigo = "";
            ViewBag.FechaDesde = "";
            ViewBag.FechaHasta = "";
        }

        public ActionResult CodigoPeriodoProductoVentaCompra()
        {
            InicializarParametrosReporteCodigoPeriodoVentaCompra();            
            return View();
        }

        [HttpPost]
        public ActionResult CodigoPeriodoProductoVentaCompra(ParametrosBusqueda parametrosBusqueda)
        {
            InicializarParametrosReporteCodigoPeriodoVentaCompra();
            ViewBag.Codigo = parametrosBusqueda.codigo;
            if(ModelState.IsValid){
                List<DetalleVenta> listDetalleVenta = unitOfWork.DetalleVentaRepository.
                                                                    GetByProductoIdEstadoIdFechaDesdeFechaHasta(
                                                                        (int)parametrosBusqueda.codigo,
                                                                        4,
                                                                        (DateTime)parametrosBusqueda.fechaDesde,
                                                                        (DateTime)parametrosBusqueda.fechaHasta);
                int cantidadVendida = listDetalleVenta.Count;
                double montoVendido = 0.00;
                foreach(DetalleVenta tempDV in listDetalleVenta){
                    montoVendido = montoVendido + (double)tempDV.Subtotal;
                }

                List<DetalleCompra> listDetalleCompra = unitOfWork.DetalleCompraRepository.
                                                                            GetByProductoIdEstadoIdFechaDesdeFechaHasta(
                                                                            (int)parametrosBusqueda.codigo,
                                                                            1,
                                                                            (DateTime)parametrosBusqueda.fechaDesde,
                                                                            (DateTime)parametrosBusqueda.fechaHasta);

                int cantidadPedidad = listDetalleCompra.Count;
                double montoPedido = 0.00;
                foreach (DetalleCompra tempDC in listDetalleCompra)
                {
                    montoPedido = montoPedido + (double)tempDC.Subtotal;
                }

                


                listDetalleCompra = unitOfWork.DetalleCompraRepository.GetByProductoIdEstadoIdFechaDesdeFechaHasta(
                                                                            (int)parametrosBusqueda.codigo,
                                                                            2,
                                                                            (DateTime)parametrosBusqueda.fechaDesde,
                                                                            (DateTime)parametrosBusqueda.fechaHasta);
                int cantidadComprada = listDetalleCompra.Count;

                double montoComprado = 0.00;
                foreach (DetalleCompra tempDC in listDetalleCompra)
                {
                    montoComprado = montoComprado + (double)tempDC.Subtotal;
                }

                ViewBag.CantidadPedida = cantidadPedidad;
                ViewBag.CantidadComprada = cantidadComprada;
                ViewBag.CantidadVendida = cantidadVendida;
                ViewBag.MontoPedido = montoPedido;
                ViewBag.MontoComprado = montoComprado;
                ViewBag.MontoVendido = montoVendido;

                ViewBag.FechaDesde = parametrosBusqueda.fechaDesde;
                ViewBag.FechaHasta = parametrosBusqueda.fechaHasta;
            }

            return View();
        }

    }
}
