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
            Session["detalleTurnos"] = new List<DetalleTurno>();

            ViewBag.Horarios = unitOfWork.HorarioRepository.Get();

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
                turno.DetalleTurnoes = Session["detalleTurnos"] as List<DetalleTurno>;

                unitOfWork.TurnoRepository.Add(turno);
                unitOfWork.TurnoRepository.Save();
                return RedirectToAction("Index");
            }

            return View(turno);
        }

        [HttpPost]
        public ActionResult CreateDetail(DetalleTurno detalleTurno) {

            List<DetalleTurno> listDetalleTurno = Session["detalleTurnos"] as List<DetalleTurno>;
            int cantidad = listDetalleTurno.Count;
            cantidad++;
            detalleTurno.TurnoId = cantidad;

            detalleTurno.Horario = unitOfWork.HorarioRepository.GetByID(detalleTurno.HorarioId);
            listDetalleTurno.Add(detalleTurno);

            Session["detalleTurnos"] = listDetalleTurno;

            ViewBag.Horarios = unitOfWork.HorarioRepository.Get();

            return View();
        }

        [HttpPost]
        public ActionResult DeleteDetail(int HorarioId)
        {
            List<DetalleTurno> listDetalleTurno = Session["detalleTurnos"] as List<DetalleTurno>;

            DetalleTurno temp = null;
            foreach(DetalleTurno item in listDetalleTurno){
                if(item.HorarioId == HorarioId){
                    temp = item;
                }
            }

            if(temp!= null){
                listDetalleTurno.Remove(temp);
            }

            
            Session["detalleTurnos"] = listDetalleTurno;
            ViewBag.DetalleTurnos = listDetalleTurno;

            return View("ListDetail");
        }

        [HttpPost]
        public ActionResult ListDetail() {
            ViewBag.DetalleTurnos = Session["detalleTurnos"] as List<DetalleTurno>;


            return View();
        }
        
        //
        // GET: /Turno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Turno turno = unitOfWork.TurnoRepository.GetByID(id);

            ViewBag.DetalleTurnos = turno.DetalleTurnoes;
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