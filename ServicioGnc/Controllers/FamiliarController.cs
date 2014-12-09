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
    public class FamiliarController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Familiar/

        public ActionResult Index()
        {
            // var clienteList = unitOfWork.ClienteRepository.Get();
            var familiars = unitOfWork.FamiliarRepository.Get(includeProperties: "Persona");
            return View(familiars.ToList());
        }

        //
        // GET: /Familiar/Details/5

        public ActionResult Details(int id = 0)
        {
            Familiar familiar = unitOfWork.FamiliarRepository.GetByID(id);
            if (familiar == null)
            {
                return HttpNotFound();
            }
            return View(familiar);
        }

        //
        // GET: /Familiar/Create

        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            return View(new Familiar());
        }

        //
        // POST: /Familiar/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Familiar familiar)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FamiliarRepository.Add(familiar);
                unitOfWork.FamiliarRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", familiar.PersonaId);
            return View(familiar);
        }

        //
        // GET: /Familiar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Familiar familiar = unitOfWork.FamiliarRepository.GetByID(id);
            if (familiar == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", familiar.PersonaId);
            return View(familiar);
        }

        //
        // POST: /Familiar/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Familiar familiar)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FamiliarRepository.Edit(familiar);
                unitOfWork.FamiliarRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", familiar.PersonaId);
            return View(familiar);
        }

        //
        // GET: /Familiar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Familiar familiar = unitOfWork.FamiliarRepository.GetByID(id);
            if (familiar == null)
            {
                return HttpNotFound();
            }
            return View(familiar);
        }

        //
        // POST: /Familiar/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Familiar familiar = unitOfWork.FamiliarRepository.GetByID(id);
            unitOfWork.FamiliarRepository.Delete(familiar);
            unitOfWork.FamiliarRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}