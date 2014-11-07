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
    public class LiquidacionController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Liquidacion/

        public ActionResult Index()
        {
            var liquidacions = unitOfWork.LiquidacionRepository.Get(includeProperties: "Persona");
            return View(liquidacions.ToList());
        }

        //
        // GET: /Liquidacion/Details/5

        public ActionResult Details(int id = 0)
        {
            Liquidacion liquidacion = unitOfWork.LiquidacionRepository.GetByID(id);
            
            if (liquidacion == null)
            {
                return HttpNotFound();
            }
            return View(liquidacion);
        }

        //
        // GET: /Liquidacion/Create

        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre");
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            return View();
        }

        //
        // POST: /Liquidacion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Liquidacion liquidacion)
        {
            if (ModelState.IsValid)
            {

                List<DetalleLiquidacion> listDetalleLiquidacion = new List<DetalleLiquidacion>();

                List<Concepto> listConcepto = unitOfWork.ConceptoRepository.Get().ToList();



                unitOfWork.LiquidacionRepository.Add(liquidacion);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre", liquidacion.EmpresaId);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", liquidacion.PersonaId);
            return View(liquidacion);
        }

        //
        // GET: /Liquidacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Liquidacion liquidacion = unitOfWork.LiquidacionRepository.GetByID(id);
            if (liquidacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre", liquidacion.EmpresaId);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", liquidacion.PersonaId);
            return View(liquidacion);
        }

        //
        // POST: /Liquidacion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Liquidacion liquidacion)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LiquidacionRepository.Edit(liquidacion);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre", liquidacion.EmpresaId);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", liquidacion.PersonaId);
            return View(liquidacion);
        }

        //
        // GET: /Liquidacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Liquidacion liquidacion = unitOfWork.LiquidacionRepository.GetByID(id);
            if (liquidacion == null)
            {
                return HttpNotFound();
            }
            return View(liquidacion);
        }

        //
        // POST: /Liquidacion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Liquidacion liquidacion = unitOfWork.LiquidacionRepository.GetByID(id);
            unitOfWork.LiquidacionRepository.Delete(liquidacion);
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