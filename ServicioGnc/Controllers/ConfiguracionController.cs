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
    public class ConfiguracionController : Controller
    {
        private ServicioGncContext db = new ServicioGncContext();

        //
        // GET: /Configuracion/

        public ActionResult Index()
        {
            return View(db.Configuracions.ToList());
        }

        //
        // GET: /Configuracion/Details/5

        public ActionResult Details(int id = 0)
        {
            Configuracion configuracion = db.Configuracions.Find(id);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(configuracion);
        }

        //
        // GET: /Configuracion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Configuracion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Configuracion configuracion)
        {
            if (ModelState.IsValid)
            {
                db.Configuracions.Add(configuracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(configuracion);
        }

        //
        // GET: /Configuracion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.MensageError = "";
            Configuracion configuracion = db.Configuracions.Find(id);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(configuracion);
        }

        //
        // POST: /Configuracion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Configuracion configuracion)
        {
            ViewBag.MensageError = "";
            if (ModelState.IsValid)
            {
                db.Entry(configuracion).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                ViewBag.MensageError = "Configuración Guardada.";
                return View(configuracion);
            }
            return View(configuracion);
        }

        //
        // GET: /Configuracion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Configuracion configuracion = db.Configuracions.Find(id);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(configuracion);
        }

        //
        // POST: /Configuracion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Configuracion configuracion = db.Configuracions.Find(id);
            db.Configuracions.Remove(configuracion);
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