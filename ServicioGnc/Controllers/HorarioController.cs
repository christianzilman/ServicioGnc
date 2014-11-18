using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioGnc.Models;

namespace ServicioGnc.Controllers
{
    public class HorarioController : Controller
    {
        private ServicioGncContext db = new ServicioGncContext();

        //
        // GET: /Horario/

        public ActionResult Index()
        {
            return View(db.Horarios.ToList());
        }

        //
        // GET: /Horario/Details/5

        public ActionResult Details(int id = 0)
        {
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        //
        // GET: /Horario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Horario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horario);
        }

        //
        // GET: /Horario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        //
        // POST: /Horario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        //
        // GET: /Horario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        //
        // POST: /Horario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horarios.Find(id);
            db.Horarios.Remove(horario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}