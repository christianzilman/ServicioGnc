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
    public class TurnoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        //
        // GET: /Turno/

        public ActionResult Index()
        {
            return View(unitOfWork.TurnoRepository.Get().ToList());
        }

        //
        // GET: /Turno/Details/5

        public ActionResult Details(int id = 0)
        {
            Turno turno = unitOfWork.TurnoRepository.GetByID(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        //
        // GET: /Turno/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Turno/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Turno turno)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TurnoRepository.Add(turno);
                unitOfWork.TurnoRepository.Save();
                return RedirectToAction("Index");
            }

            return View(turno);
        }

        //
        // GET: /Turno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Turno turno = unitOfWork.TurnoRepository.GetByID(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        //
        // POST: /Turno/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Turno turno)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TurnoRepository.Edit(turno);
                unitOfWork.TurnoRepository.Save();
                return RedirectToAction("Index");
            }
            return View(turno);
        }

        //
        // GET: /Turno/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Turno turno = unitOfWork.TurnoRepository.GetByID(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        //
        // POST: /Turno/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turno turno = unitOfWork.TurnoRepository.GetByID(id);
            unitOfWork.TurnoRepository.Delete(turno);
            unitOfWork.TurnoRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}