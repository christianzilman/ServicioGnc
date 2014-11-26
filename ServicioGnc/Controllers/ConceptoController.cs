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
    public class ConceptoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
       
        //
        // GET: /Concepto/

        public ActionResult Index()
        {
            var conceptoes = unitOfWork.ConceptoRepository.Get(includeProperties: "TipoConcepto");
            return View(conceptoes.ToList());
        }

        //
        // GET: /Concepto/Details/5

        public ActionResult Details(int id = 0)
        {

            Concepto concepto = unitOfWork.ConceptoRepository.GetByID(id);
            if (concepto == null)
            {
                return HttpNotFound();
            }
            return View(concepto);
        }

        //
        // GET: /Concepto/Create

        public ActionResult Create()
        {
            ViewBag.TipoConceptoId = new SelectList(unitOfWork.ConceptoRepository.Get(), "TipoConceptoId", "Nombre");
            return View();
        }

        //
        // POST: /Concepto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ConceptoRepository.Add(concepto);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.TipoConceptoId = new SelectList(unitOfWork.ConceptoRepository.Get(), "TipoConceptoId", "Nombre", concepto.TipoConceptoId);

            return View(concepto);
        }

        //
        // GET: /Concepto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Concepto concepto = unitOfWork.ConceptoRepository.GetByID(id);
            if (concepto == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.TipoConceptoId = new SelectList(unitOfWork.ConceptoRepository.Get(), "TipoConceptoId", "Nombre", concepto.TipoConceptoId);
            return View(concepto);
        }

        //
        // POST: /Concepto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ConceptoRepository.Edit(concepto);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.TipoConceptoId = new SelectList(unitOfWork.ConceptoRepository.Get(), "TipoConceptoId", "Nombre", concepto.TipoConceptoId);
            return View(concepto);
        }

        //
        // GET: /Concepto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Concepto concepto = unitOfWork.ConceptoRepository.GetByID(id);
            if (concepto == null)
            {
                return HttpNotFound();
            }
            return View(concepto);
        }

        [HttpPost]
        public ActionResult BuscarConcepto(int conceptoId)
        {
            Concepto concepto = unitOfWork.ConceptoRepository.GetByID(conceptoId);
            ViewBag.ConceptoId = conceptoId;
            ViewBag.Nombre = concepto.Nombre;
            ViewBag.Importe = concepto.Importe;
            return View();

        }

        //
        // POST: /Concepto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Concepto concepto = unitOfWork.ConceptoRepository.GetByID(id);
            unitOfWork.ConceptoRepository.Delete(concepto);
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