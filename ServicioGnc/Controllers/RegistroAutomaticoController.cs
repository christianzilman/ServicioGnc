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
    public class RegistroAutomaticoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /RegistroAutomatico/

        public ActionResult Index()
        {
            var registroautomaticoes = unitOfWork.RegistroAutomaticoRepository.Get(includeProperties :"TurnoEspecial");//db.RegistroAutomaticoes.Include(r => r.TurnoEspecial);
            return View(registroautomaticoes.ToList());
        }

        //
        // GET: /RegistroAutomatico/Details/5


        public ActionResult Details(int id = 0)
        {
            RegistroAutomatico registroautomatico = unitOfWork.RegistroAutomaticoRepository.GetByID(id);
            if (registroautomatico == null)
            {
                return HttpNotFound();
            }
            return View(registroautomatico);
        }

        [HttpGet]
        public ActionResult CreateGeneral() {
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult CreateGeneral(int id) {

            DateTime fechaActual = DateTime.Now;

            List<Feriado> listFeriado = unitOfWork.FeriadoRepository.GetByGreaterThanDate(fechaActual);        

            return View("Index");
        }

        //
        // GET: /RegistroAutomatico/Create


        public ActionResult Create()
        {
            ViewBag.TurnoEspecialId = new SelectList(unitOfWork.TurnoEspecialRepository.Get(), "TurnoEspecialId", "TurnoEspecialId");
            return View();
        }

        //
        // POST: /RegistroAutomatico/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroAutomatico registroautomatico)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.RegistroAutomaticoRepository.Add(registroautomatico);                
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.TurnoEspecialId = new SelectList(unitOfWork.TurnoEspecialRepository.Get(), "TurnoEspecialId", "TurnoEspecialId", registroautomatico.TurnoEspecialId);
            return View(registroautomatico);
        }

        //
        // GET: /RegistroAutomatico/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RegistroAutomatico registroautomatico = unitOfWork.RegistroAutomaticoRepository.GetByID(id);
            if (registroautomatico == null)
            {
                return HttpNotFound();
            }
            ViewBag.TurnoEspecialId = new SelectList(unitOfWork.TurnoEspecialRepository.Get(), "TurnoEspecialId", "TurnoEspecialId", registroautomatico.TurnoEspecialId);
            return View(registroautomatico);
        }

        //
        // POST: /RegistroAutomatico/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegistroAutomatico registroautomatico)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.RegistroAutomaticoRepository.Edit(registroautomatico);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.TurnoEspecialId = new SelectList(unitOfWork.TurnoEspecialRepository.Get(), "TurnoEspecialId", "TurnoEspecialId", registroautomatico.TurnoEspecialId);
            return View(registroautomatico);
        }

        //
        // GET: /RegistroAutomatico/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RegistroAutomatico registroautomatico = unitOfWork.RegistroAutomaticoRepository.GetByID(id);
            if (registroautomatico == null)
            {
                return HttpNotFound();
            }
            return View(registroautomatico);
        }

        //
        // POST: /RegistroAutomatico/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroAutomatico registroautomatico = unitOfWork.RegistroAutomaticoRepository.GetByID(id);
            unitOfWork.RegistroAutomaticoRepository.Delete(registroautomatico);
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