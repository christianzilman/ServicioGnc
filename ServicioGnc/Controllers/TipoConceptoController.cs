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
    public class TipoConceptoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        //
        // GET: /TipoConcepto/

        public ActionResult Index()
        {

            var tipoConceptoList = unitOfWork.TipoConceptoRepository.Get();   
            return View(tipoConceptoList.ToList());
        }

        //
        // GET: /TipoConcepto/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoConcepto tipoconcepto = unitOfWork.TipoConceptoRepository.GetByID(id);
            if (tipoconcepto == null)
            {
                return HttpNotFound();
            }
            return View(tipoconcepto);
        }

        //
        // GET: /TipoConcepto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoConcepto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoConcepto tipoconcepto)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TipoConceptoRepository.Add(tipoconcepto);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(tipoconcepto);
        }

        //
        // GET: /TipoConcepto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoConcepto tipoconcepto = unitOfWork.TipoConceptoRepository.GetByID(id);
            if (tipoconcepto == null)
            {
                return HttpNotFound();
            }
            return View(tipoconcepto);
        }

        //
        // POST: /TipoConcepto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoConcepto tipoconcepto)
        {
            if (ModelState.IsValid)
            {

                
                unitOfWork.TipoConceptoRepository.Edit(tipoconcepto);
                unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            return View(tipoconcepto);
        }

        //
        // GET: /TipoConcepto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoConcepto tipoconcepto = unitOfWork.TipoConceptoRepository.GetByID(id);
            
            if (tipoconcepto == null)
            {
                return HttpNotFound();
            }
            return View(tipoconcepto);
        }

        //
        // POST: /TipoConcepto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoConcepto tipoconcepto = unitOfWork.TipoConceptoRepository.GetByID(id);
            unitOfWork.TipoConceptoRepository.Delete(tipoconcepto);
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