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
    public class FeriadoController : Controller
    {
        private UnitOfWork unitOFWork = new UnitOfWork();
        
        //
        // GET: /Feriado/

        public ActionResult Index()
        {
            return View(unitOFWork.FeriadoRepository.Get().ToList());
        }

        //
        // GET: /Feriado/Details/5

        public ActionResult Details(int id = 0)
        {
            Feriado feriado = unitOFWork.FeriadoRepository.GetByID(id);
            
            if (feriado == null)
            {
                return HttpNotFound();
            }
            return View(feriado);
        }

        //
        // GET: /Feriado/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Feriado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feriado feriado)
        {
            if (ModelState.IsValid)
            {
                unitOFWork.FeriadoRepository.Add(feriado);
                unitOFWork.Save();
                return RedirectToAction("Index");
            }

            return View(feriado);
        }

        //
        // GET: /Feriado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Feriado feriado = unitOFWork.FeriadoRepository.GetByID(id);
            if (feriado == null)
            {
                return HttpNotFound();
            }
            return View(feriado);
        }

        //
        // POST: /Feriado/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Feriado feriado)
        {
            if (ModelState.IsValid)
            {
                unitOFWork.FeriadoRepository.Edit(feriado);
                unitOFWork.Save();
                return RedirectToAction("Index");
            }
            return View(feriado);
        }

        //
        // GET: /Feriado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Feriado feriado = unitOFWork.FeriadoRepository.GetByID(id);
            if (feriado == null)
            {
                return HttpNotFound();
            }
            return View(feriado);
        }

        //
        // POST: /Feriado/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feriado feriado = unitOFWork.FeriadoRepository.GetByID(id);
            unitOFWork.FeriadoRepository.Delete(feriado);
            unitOFWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOFWork.Dispose();
            base.Dispose(disposing);
        }
    }
}