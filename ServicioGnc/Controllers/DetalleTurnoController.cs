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
    public class DetalleTurnoController : Controller
    {
        private ServicioGncContext db = new ServicioGncContext();

        //
        // GET: /DetalleTurno/

        public ActionResult Index()
        {
            var detalleturnoes = db.DetalleTurnoes.Include(d => d.Horario).Include(d => d.Turno);
            return View(detalleturnoes.ToList());
        }

        //
        // GET: /DetalleTurno/Details/5

        public ActionResult Details(int id = 0)
        {
            DetalleTurno detalleturno = db.DetalleTurnoes.Find(id);
            if (detalleturno == null)
            {
                return HttpNotFound();
            }
            return View(detalleturno);
        }

        //
        // GET: /DetalleTurno/Create

        public ActionResult Create()
        {
            ViewBag.HorarioId = new SelectList(db.Horarios, "HorarioId", "ComienzoTurno");
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre");
            return View();
        }

        //
        // POST: /DetalleTurno/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleTurno detalleturno)
        {
            if (ModelState.IsValid)
            {
                db.DetalleTurnoes.Add(detalleturno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HorarioId = new SelectList(db.Horarios, "HorarioId", "ComienzoTurno", detalleturno.HorarioId);
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre", detalleturno.TurnoId);
            return View(detalleturno);
        }

        //
        // GET: /DetalleTurno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DetalleTurno detalleturno = db.DetalleTurnoes.Find(id);
            if (detalleturno == null)
            {
                return HttpNotFound();
            }
            ViewBag.HorarioId = new SelectList(db.Horarios, "HorarioId", "ComienzoTurno", detalleturno.HorarioId);
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre", detalleturno.TurnoId);
            return View(detalleturno);
        }

        //
        // POST: /DetalleTurno/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleTurno detalleturno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleturno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HorarioId = new SelectList(db.Horarios, "HorarioId", "ComienzoTurno", detalleturno.HorarioId);
            ViewBag.TurnoId = new SelectList(db.Turnoes, "TurnoId", "Nombre", detalleturno.TurnoId);
            return View(detalleturno);
        }

        //
        // GET: /DetalleTurno/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DetalleTurno detalleturno = db.DetalleTurnoes.Find(id);
            if (detalleturno == null)
            {
                return HttpNotFound();
            }
            return View(detalleturno);
        }

        //
        // POST: /DetalleTurno/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleTurno detalleturno = db.DetalleTurnoes.Find(id);
            db.DetalleTurnoes.Remove(detalleturno);
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