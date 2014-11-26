using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioGnc.Models;
using ServicioGnc.DAL;
using WebMatrix.WebData;
using Rotativa;

namespace ServicioGnc.Controllers
{
    [Authorize]
    public class CarroController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Carro/

        public ActionResult Index()
        {
            return View(unitOfWork.CarroRepository.Get());
        }

        //
        // GET: /Carro/Details/5

        public ActionResult Details(int id = 0)
        {
            Carro carro = unitOfWork.CarroRepository.GetByID(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        [HttpPost]
        public ActionResult SeleccionarProveedor()
        {
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "RazonSocial");
            return View();
        }
        //
        // GET: /Carro/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(unitOfWork.ClienteRepository.Get(), "ClienteId", "Nombre");
            return View();
        }

        [Authorize]
        public ActionResult CreateCompra()
        {
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "RazonSocial");
            return View();
        }
        public ActionResult CreateLiquidacion()
        {
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            return View();
        }

        public ActionResult AgregarDetalle(int productoId, int cantidad, int tipoOperacionId)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(productoId);

            Carro carro = new Carro();
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            carro.UsuarioId = UserId;
            // tipo operacion 1:Venta  2:Compra
            carro.TipoOperacionId = tipoOperacionId;
            carro.Cantidad = (double)cantidad;
            carro.ProductoId = productoId;
            carro.SubTotal = producto.PrecioVenta * (double)cantidad;
            carro.Precio = producto.PrecioVenta;

            unitOfWork.CarroRepository.Add(carro);
            unitOfWork.CarroRepository.Save();

            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacionUsuario(1,UserId); //CarroRepository.Get(includeProperties :"Producto").ToList();
            ViewBag.ListCarro = listCarro;
            return View();
        }

        public ActionResult AgregarDetalleCompra(int productoId, int cantidad, int tipoOperacionId)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(productoId);

            Carro carro = new Carro();
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            carro.UsuarioId = UserId;
            // tipo operacion 1:Venta  2:Compra
            carro.TipoOperacionId = tipoOperacionId;
            carro.Cantidad = (double)cantidad;
            carro.ProductoId = productoId;
            carro.SubTotal = producto.PrecioCompra * (double)cantidad;
            carro.Precio = producto.PrecioCompra;

            unitOfWork.CarroRepository.Add(carro);
            unitOfWork.CarroRepository.Save();

            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacionUsuario(2,UserId); //CarroRepository.Get(includeProperties :"Producto").ToList();
            ViewBag.ListCarro = listCarro;
            return View();
        }

        public ActionResult EliminarDetalle(int carroId)
        {

            Carro carro = unitOfWork.CarroRepository.GetByID(carroId);
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            // tipo operacion 1:Venta  2:Compra
            carro.TipoOperacionId = 1;
            unitOfWork.CarroRepository.Delete(carro);
            unitOfWork.CarroRepository.Save();
            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacionUsuario(1,UserId);
            ViewBag.ListCarro = listCarro;
            return View("AgregarDetalle");
        }

        public ActionResult EliminarDetalleCompra(int carroId)
        {

            Carro carro = unitOfWork.CarroRepository.GetByID(carroId);
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            // tipo operacion 1:Venta  2:Compra
            carro.TipoOperacionId = 2;
            unitOfWork.CarroRepository.Delete(carro);
            unitOfWork.CarroRepository.Save();
            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacionUsuario(1, UserId);
            ViewBag.ListCarro = listCarro;
            return View("AgregarDetalle");
        }

        [Authorize]
        [HttpPost]
        public ActionResult ProcesarVenta(int ClienteId)
        {

            int UserId = WebSecurity.GetUserId(User.Identity.Name);

            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacionUsuario(1,UserId); //unitOfWork.CarroRepository.Get(includeProperties:"Producto").ToList();
            

            double total = (double)listCarro.Sum<Carro>(t=>t.SubTotal);
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "Cliente", "Nombre");

            Venta venta = new Venta();
            venta.Total = total;
            venta.UsuarioId = UserId;
            venta.Fecha = DateTime.Now;
            venta.ClienteId = ClienteId;
            //ESTADOS: 1=Pendiente 2=Confirmado 3=Cancelado
            venta.TipoEstadoId = 4;

            List<DetalleVenta> listDetalleVenta = new List<DetalleVenta>();
            foreach(Carro carro in listCarro){
                DetalleVenta detalleVenta = new DetalleVenta();
                detalleVenta.Cantidad = (double)carro.Cantidad;
                detalleVenta.Subtotal = carro.SubTotal;
                detalleVenta.ProductoId = carro.ProductoId;
                detalleVenta.Precio = carro.Precio;

                listDetalleVenta.Add(detalleVenta);

            }

            venta.DetalleVentas = listDetalleVenta;
            unitOfWork.VentaRepository.Add(venta);
            unitOfWork.Save();
            foreach(Carro carro in listCarro)
            {
                unitOfWork.CarroRepository.Delete(carro);
            }
            unitOfWork.Save();

            return new ActionAsPdf(
                "ImprimirVenta",
                new { VentaId = venta.VentaId });
            //return View();
        }


        public ActionResult ImprimirVenta(int VentaId)
        {
            Venta venta = unitOfWork.VentaRepository.GetByID(VentaId);
            ViewBag.Venta = unitOfWork.VentaRepository.GetByID(VentaId);
            ViewBag.DetalleVenta = venta.DetalleVentas;
            return View(venta);
        }

        public ActionResult ImprimirCompra(int CompraId)
        {
            Compra compra = unitOfWork.CompraRepository.GetByID(CompraId);
            ViewBag.Compra = unitOfWork.CompraRepository.GetByID(CompraId);
            ViewBag.DetalleCompra = compra.DetalleCompras;
            return View(compra);
        }



        [HttpPost]
        public ActionResult ProcesarCompra(int ProveedorId)
        {
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            
            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacionUsuario(2,UserId); //unitOfWork.CarroRepository.Get(includeProperties: "Producto").ToList();

            double total = (double)listCarro.Sum<Carro>(t => t.SubTotal);
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "RazonSocial");
            
            Compra compra = new Compra();
            // --
            compra.Total = total;
            compra.Fecha = DateTime.Now;
            //ESTADOS: 1=Pendiente 2=Confirmado 3=Cancelado
            compra.TipoEstadoId = 1;
            compra.ProveedorId = ProveedorId;
            compra.UsuarioId = UserId;

            List<DetalleCompra> listDetalleCompra = new List<DetalleCompra>();
            foreach (Carro carro in listCarro)
            {
                DetalleCompra detalleCompra = new DetalleCompra();
                detalleCompra.Cantidad = (double)carro.Cantidad;
                detalleCompra.Subtotal = carro.SubTotal;
                detalleCompra.ProductoId = carro.ProductoId;
                detalleCompra.Precio = carro.Precio;

                listDetalleCompra.Add(detalleCompra);

            }

            compra.DetalleCompras = listDetalleCompra;
            unitOfWork.CompraRepository.Add(compra);
            unitOfWork.Save();
            foreach (Carro carro in listCarro)
            {
                unitOfWork.CarroRepository.Delete(carro);
            }
            unitOfWork.Save();

            return new ActionAsPdf(
                "ImprimirCompra",
                new { CompraId = compra.CompraId });
            //return View();
        }

        public ActionResult ProcesarLiquidacion()
        {
            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacion(3); //unitOfWork.CarroRepository.Get(includeProperties:"Producto").ToList();

            double total = (double)listCarro.Sum<Carro>(t => t.SubTotal);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");

            Venta venta = new Venta();
            Liquidacion liquidacion = new Liquidacion();
            liquidacion.PersonaId = 1;
            liquidacion.Fecha = DateTime.Today;
            liquidacion.Periodo = "10-2014";//Convert.ToString(DateTime.Now.Month) ;
            liquidacion.Total = total;

            List<DetalleLiquidacion> listDetalleLiquidacion = new List<DetalleLiquidacion>();
            foreach (Carro carro in listCarro)
            {
                DetalleLiquidacion detalleLiquidacion = new DetalleLiquidacion();
                detalleLiquidacion.SubTotal = carro.SubTotal;
                detalleLiquidacion.ConceptoId = carro.ProductoId;

                listDetalleLiquidacion.Add(detalleLiquidacion);

            }

            liquidacion.DetalleLiquidacions = listDetalleLiquidacion;
            unitOfWork.LiquidacionRepository.Add(liquidacion);
            unitOfWork.Save();
            foreach (Carro carro in listCarro)
            {
                unitOfWork.CarroRepository.Delete(carro);
            }
            unitOfWork.Save();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompra(Carro carro)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CarroRepository.Add(carro);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "Nombre");
            return View(carro);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLiquidacion(Carro carro)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CarroRepository.Add(carro);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "Nombre");
            return View(carro);
        }

        //
        // POST: /Carro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carro carro)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CarroRepository.Add(carro);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(unitOfWork.ClienteRepository.Get(), "ClienteId", "Nombre");
            return View(carro);
        }

        //
        // GET: /Carro/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Carro carro = unitOfWork.CarroRepository.GetByID(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        //
        // POST: /Carro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carro carro)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CarroRepository.Edit(carro);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        //
        // GET: /Carro/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Carro carro = unitOfWork.CarroRepository.GetByID(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        //
        // POST: /Carro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = unitOfWork.CarroRepository.GetByID(id);
            unitOfWork.CarroRepository.Delete(carro);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}