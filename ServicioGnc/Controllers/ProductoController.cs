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
    public class ProductoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Producto/

        public ActionResult Index(string searchString)
        {
            var productoes = unitOfWork.ProductoRepository.Get(includeProperties: "Unidad");

            if (!String.IsNullOrEmpty(searchString))
            {
                productoes = productoes.Where(p => p.Nombre.ToUpper().Contains(searchString.ToUpper()));

            }

            return View(productoes.ToList());
        }



        [HttpPost]
        public ActionResult BuscarProducto(int productoId)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(productoId);
            ViewBag.ProductoId = productoId;
            ViewBag.NombreProducto = producto.Nombre;
            ViewBag.PrecioVenta = producto.PrecioVenta;
            ViewBag.Cantidad = producto.Cantidad;
            return View();

        }

        [HttpPost]
        public ActionResult BuscarProductoCompra(int productoId)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(productoId);
            ViewBag.ProductoId = productoId;
            ViewBag.NombreProducto = producto.Nombre;
            ViewBag.PrecioCompra = producto.PrecioCompra;
            return View();

        }

        [HttpPost]
        public ActionResult BuscarProductoReporte(int productoId)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(productoId);
            ViewBag.ProductoId = productoId;
            ViewBag.NombreProducto = producto.Nombre;
            ViewBag.PrecioVenta = producto.PrecioVenta;
            ViewBag.PrecioCompra = producto.PrecioCompra;
            ViewBag.Cantidad = producto.Cantidad;

            return View();

        }
        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id = 0)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            ViewBag.UnidadId = new SelectList(unitOfWork.UnidadRepository.Get(), "UnidadId", "Nombre");
            return View();
        }

        //
        // POST: /Producto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                double utilidad = (double)producto.Utilidad / 100.00;

                producto.PrecioVenta = producto.PrecioCompra + (producto.PrecioCompra * utilidad); 
                producto.Cantidad = 0;
                unitOfWork.ProductoRepository.Add(producto);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.UnidadId = new SelectList(unitOfWork.UnidadRepository.Get(), "UnidadId", "Nombre", producto.UnidadId);
            return View(producto);
        }

        //
        // GET: /Producto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadId = new SelectList(unitOfWork.UnidadRepository.Get(), "UnidadId", "Nombre", producto.UnidadId);
            return View(producto);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                double utilidad = (double)producto.Utilidad / 100.00;
                producto.PrecioVenta = producto.PrecioCompra + (producto.PrecioCompra * utilidad); 
                unitOfWork.ProductoRepository.Edit(producto);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadId = new SelectList(unitOfWork.UnidadRepository.Get(), "UnidadId", "Nombre", producto.UnidadId);
            return View(producto);
        }

        //
        // GET: /Producto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = unitOfWork.ProductoRepository.GetByID(id);
            unitOfWork.ProductoRepository.Delete(producto);
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