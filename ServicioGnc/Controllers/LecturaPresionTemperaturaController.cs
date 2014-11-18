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
    public class LecturaPresionTemperaturaController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        //
        // GET: /LecturaPresionTemperatura/

        public ActionResult Index()
        {
            
            return View(unitOfWork.LecturaPresionTemperaturaRepository.Get().ToList());

        }

        //
        // GET: /LecturaPresionTemperatura/Details/5

        public ActionResult Details(int id = 0)
        {
            LecturaPresionTemperatura lecturapresiontemperatura = unitOfWork.LecturaPresionTemperaturaRepository.GetByID(id);
            if (lecturapresiontemperatura == null)
            {
                return HttpNotFound();
            }
            return View(lecturapresiontemperatura);
        }

        //
        // GET: /LecturaPresionTemperatura/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LecturaPresionTemperatura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LecturaPresionTemperatura lecturapresiontemperatura)
        {
            Random rng = new Random();
            
            double presion;
            presion = rng.Next(200,260);

            double temperatura;
            temperatura = rng.Next(0,60);

            lecturapresiontemperatura.Nombre = "Lectura";
            lecturapresiontemperatura.Presion = presion;
            lecturapresiontemperatura.Temperatura = temperatura;
            lecturapresiontemperatura.Fecha = DateTime.Today;

            if (ModelState.IsValid)
            {
                unitOfWork.LecturaPresionTemperaturaRepository.Add(lecturapresiontemperatura);
                unitOfWork.LecturaPresionTemperaturaRepository.Save();
                return RedirectToAction("Index");
            }

            return View(lecturapresiontemperatura);
        }

        //
        // GET: /LecturaPresionTemperatura/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LecturaPresionTemperatura lecturapresiontemperatura = unitOfWork.LecturaPresionTemperaturaRepository.GetByID(id);
            if (lecturapresiontemperatura == null)
            {
                return HttpNotFound();
            }
            return View(lecturapresiontemperatura);
        }

        //
        // POST: /LecturaPresionTemperatura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LecturaPresionTemperatura lecturapresiontemperatura)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LecturaPresionTemperaturaRepository.Edit(lecturapresiontemperatura);
                unitOfWork.LecturaPresionTemperaturaRepository.Save();
                return RedirectToAction("Index");
            }
            return View(lecturapresiontemperatura);
        }

        //
        // GET: /LecturaPresionTemperatura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LecturaPresionTemperatura lecturapresiontemperatura = unitOfWork.LecturaPresionTemperaturaRepository.GetByID(id);
            if (lecturapresiontemperatura == null)
            {
                return HttpNotFound();
            }
            return View(lecturapresiontemperatura);
        }

        //
        // POST: /LecturaPresionTemperatura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LecturaPresionTemperatura lecturapresiontemperatura = unitOfWork.LecturaPresionTemperaturaRepository.GetByID(id);
            unitOfWork.LecturaPresionTemperaturaRepository.Delete(lecturapresiontemperatura);
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