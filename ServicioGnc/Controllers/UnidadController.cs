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
    public class UnidadController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Unidad/

        public ActionResult Index()
        {
            var unidadlist = unitOfWork.UnidadRepository.Get();
            return View(unidadlist.ToList());
        }

        //
        // GET: /Unidad/Details/5

        public ActionResult Details(int id = 0)
        {
            Unidad unidad = unitOfWork.UnidadRepository.GetByID(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        //
        // GET: /Unidad/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Unidad/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UnidadRepository.Add(unidad);
                unitOfWork.UnidadRepository.Save();
                return RedirectToAction("Index");
            }

            return View(unidad);
        }

        //
        // GET: /Unidad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Unidad unidad = unitOfWork.UnidadRepository.GetByID(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        //
        // POST: /Unidad/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UnidadRepository.Edit(unidad);
                unitOfWork.UnidadRepository.Save();
                return RedirectToAction("Index");
            }
            return View(unidad);
        }

        //
        // GET: /Unidad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Unidad unidad = unitOfWork.UnidadRepository.GetByID(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        //
        // POST: /Unidad/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidad unidad = unitOfWork.UnidadRepository.GetByID(id);
            unitOfWork.UnidadRepository.Edit(unidad);
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