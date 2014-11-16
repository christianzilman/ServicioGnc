using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioGnc.Models;
using ServicioGnc.DAL;

namespace ServicioGnc.Controllers
{
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

        //
        // GET: /Carro/Create

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateCompra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarDetalle(int productoId,int cantidad, int tipoOperacionId)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(productoId);

            Carro carro = new Carro();
            // tipo operacion 1:Venta  2:Compra
            carro.TipoOperacionId = tipoOperacionId;
            carro.Cantidad = (double)cantidad;
            carro.ProductoId = productoId;
            carro.SubTotal = producto.PrecioVenta * (double)cantidad;
            carro.Precio = producto.PrecioVenta;

            unitOfWork.CarroRepository.Add(carro);
            unitOfWork.CarroRepository.Save();

            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacion(1); //CarroRepository.Get(includeProperties :"Producto").ToList();
            ViewBag.ListCarro = listCarro;
            return View();
        }
        [HttpPost]
        public ActionResult ProcesarVenta() {
            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacion(1); //unitOfWork.CarroRepository.Get(includeProperties:"Producto").ToList();

            double total = (double)listCarro.Sum<Carro>(t=>t.SubTotal);

            Venta venta = new Venta();
            venta.ClienteId = 1;
            venta.Total = total;
            venta.Fecha = DateTime.Now;

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

            return View();
        }


        [HttpPost]
        public ActionResult ProcesarCompra()
        {
            List<Carro> listCarro = unitOfWork.CarroRepository.GetByTipoOperacion(2); //unitOfWork.CarroRepository.Get(includeProperties: "Producto").ToList();

            double total = (double)listCarro.Sum<Carro>(t => t.SubTotal);

            Compra compra = new Compra();
            compra.ProveedorId = 1;
            compra.Total = total;
            compra.Fecha = DateTime.Now;


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