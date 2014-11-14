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
    public class AsignacionTurnoController : Controller
    {
        private ServicioGncContext db = new ServicioGncContext();

        //
        // GET: /AsignacionTurno/

        public ActionResult Index()
        {
            var asignacionturnoes = db.AsignacionTurnoes.Include(a => a.Persona).Include(a => a.Turno);
            return View(asignacionturnoes.ToList());
        }

        //
        // GET: /AsignacionTurno/Details/5

        public ActionResult Details(int id = 0)
        {
            AsignacionTurno asignacionturno = db.AsignacionTurnoes.Find(id);
            if (asignacionturno == null)
            {
                return HttpNotFound();
            }
            return View(asignacionturno);
        }

        //
        // GET: /AsignacionTurno/Create

        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "Nombre");
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre");
            return View();
        }

        //
        // POST: /AsignacionTurno/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsignacionTurno asignacionturno)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionTurnoes.Add(asignacionturno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "Nombre", asignacionturno.PersonaId);
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre", asignacionturno.TurnoId);
            return View(asignacionturno);
        }

        //
        // GET: /AsignacionTurno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AsignacionTurno asignacionturno = db.AsignacionTurnoes.Find(id);
            if (asignacionturno == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "Nombre", asignacionturno.PersonaId);
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre", asignacionturno.TurnoId);
            return View(asignacionturno);
        }

        //
        // POST: /AsignacionTurno/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AsignacionTurno asignacionturno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionturno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "Nombre", asignacionturno.PersonaId);
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre", asignacionturno.TurnoId);
            return View(asignacionturno);
        }

        //
        // GET: /AsignacionTurno/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AsignacionTurno asignacionturno = db.AsignacionTurnoes.Find(id);
            if (asignacionturno == null)
            {
                return HttpNotFound();
            }
            return View(asignacionturno);
        }

        //
        // POST: /AsignacionTurno/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionTurno asignacionturno = db.AsignacionTurnoes.Find(id);
            db.AsignacionTurnoes.Remove(asignacionturno);
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