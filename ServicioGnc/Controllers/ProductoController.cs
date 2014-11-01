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

        public ActionResult Index()
        {
            var productoes = unitOfWork.ProductoRepository.Get(includeProperties: "Unidad");
            return View(productoes.ToList());
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