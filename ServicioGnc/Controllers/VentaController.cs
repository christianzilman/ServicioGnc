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
    public class VentaController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Venta/

        public ActionResult Index()
        {
            var ventas = unitOfWork.VentaRepository.Get(includeProperties: "Cliente").Where(t => t.TipoEstadoId == 4);
            return View(ventas.ToList());
        }

        //
        // GET: /Venta/Details/5

        public ActionResult Details(int id = 0)
        {
            Venta venta = unitOfWork.VentaRepository.GetByID(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        //
        // GET: /Venta/Create

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(unitOfWork.ClienteRepository.Get(), "ClienteId", "Nombre");
            return View();
        }

        //
        // POST: /Venta/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.VentaRepository.Add(venta);
                unitOfWork.VentaRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(unitOfWork.ClienteRepository.Get(), "ClienteId", "Nombre", venta.ClienteId);
            return View(venta);
        }

        //
        // GET: /Venta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Venta venta = unitOfWork.VentaRepository.GetByID(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(unitOfWork.ClienteRepository.Get(), "ClienteId", "Nombre", venta.ClienteId);
            ViewBag.TipoEstadoId = new SelectList(unitOfWork.TipoEstadoRepository.Get().Where(t => t.TipoEstadoId > 4), "TipoEstadoId", "Nombre", venta.TipoEstadoId);
            return View(venta);
        }

        //
        // POST: /Venta/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venta venta)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.VentaRepository.Edit(venta);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(unitOfWork.ClienteRepository.Get(), "ClienteId", "Nombre", venta.ClienteId);
            ViewBag.TipoEstadoId = new SelectList(unitOfWork.TipoEstadoRepository.Get().Where(t => t.TipoEstadoId > 4), "TipoEstadoId", "Nombre", venta.TipoEstadoId);
            return View(venta);
        }

        //
        // GET: /Venta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Venta venta = unitOfWork.VentaRepository.GetByID(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        //
        // POST: /Venta/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = unitOfWork.VentaRepository.GetByID(id);
            unitOfWork.VentaRepository.Delete(venta);
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