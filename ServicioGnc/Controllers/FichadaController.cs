using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioGnc.DAL;
using ServicioGnc.Models;

namespace ServicioGnc.Controllers
{
    public class FichadaController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        //
        // GET: /Fichada/

        public ActionResult Index()
        {
            var fichadas = unitOfWork.FichadaRepository.Get();
            return View(fichadas.ToList());
        }

        //
        // GET: /Fichada/Details/5

        public ActionResult Details(int id = 0)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            if (fichada == null)
            {
                return HttpNotFound();
            }
            return View(fichada);
        }

        //
        // GET: /Fichada/Create

        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            return View();
        }

        //
        // POST: /Fichada/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fichada fichada)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FichadaRepository.Add(fichada);
                unitOfWork.FichadaRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", fichada.PersonaId);
            return View(fichada);
        }

        //
        // GET: /Fichada/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            if (fichada == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", fichada.PersonaId);
            return View(fichada);
        }

        //
        // POST: /Fichada/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fichada fichada)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FichadaRepository.Edit(fichada);
                unitOfWork.FichadaRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", fichada.PersonaId);
            return View(fichada);
        }

        //
        // GET: /Fichada/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            if (fichada == null)
            {
                return HttpNotFound();
            }
            return View(fichada);
        }

        //
        // POST: /Fichada/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            unitOfWork.FichadaRepository.Delete(fichada);
            unitOfWork.FichadaRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}