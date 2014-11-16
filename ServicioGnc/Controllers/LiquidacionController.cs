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
/*
        public ActionResult Index()
        {
            var liquidacions = unitOfWork.LiquidacionRepository.Get(includeProperties: "Persona");
            return View(liquidacions.ToList());
        }
        */
       // [HttpPost]
        public ActionResult Index(string periodo)
        {
            var liquidacions = unitOfWork.LiquidacionRepository.Get(includeProperties: "Persona");
            if (!String.IsNullOrEmpty(periodo))
            {
            liquidacions = liquidacions.Where(l => l.Periodo.ToUpper().Contains(periodo.ToUpper()));
           
            }
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

        public ActionResult CreateGeneral()
        {
            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGeneral(Liquidacion liquidacion)
        {
            try
            {
                foreach(Persona persona in unitOfWork.PersonaRepository.Get().ToList())
                {
                    Liquidacion liquidacionGeneral = new Liquidacion();

                    liquidacionGeneral.Persona = persona;
                    liquidacionGeneral.PersonaId = persona.PersonaId;
                    liquidacionGeneral.Fecha = liquidacion.Fecha;
                    liquidacionGeneral.Periodo = liquidacion.Periodo;
                    liquidacionGeneral.Empresa = liquidacion.Empresa;
                    liquidacionGeneral.EmpresaId = liquidacion.EmpresaId;

                    List<DetalleLiquidacion> listDetalleLiquidacion = new List<DetalleLiquidacion>();

                    List<Concepto> listConcepto = unitOfWork.ConceptoRepository.Get().ToList();
                    double importeTotal = 0.00;
                    foreach (Concepto concepto in listConcepto)
                    {
                        switch (concepto.ConceptoId)
                        {
                            case 1:
                                importeTotal = importeTotal + (double)concepto.Importe;
                                break;
                            default:
                                importeTotal = calcularSueldo(importeTotal, (double)concepto.Importe, (double)concepto.Porcentaje, (int)concepto.Utilidad, (int)concepto.TipoConceptoId);
                                break;
                        }
                    }

                    liquidacionGeneral.Total = importeTotal;

                    double importeTemp = 0.00;
                    double sueldoBasico = 0.00;
                    foreach (Concepto concepto in listConcepto)
                    {
                        DetalleLiquidacion detalleLiquidacion = new DetalleLiquidacion();
                        detalleLiquidacion.ConceptoId = concepto.ConceptoId;
                        importeTemp = 0.00;
                        switch (concepto.ConceptoId)
                        {
                            case 1:
                                sueldoBasico = (double)concepto.Importe;
                                importeTemp = sueldoBasico;
                                break;
                            default:
                                importeTemp = calcularSueldo(sueldoBasico, (double)concepto.Importe, (double)concepto.Porcentaje, (int)concepto.Utilidad, (int)concepto.TipoConceptoId);
                                break;
                        }
                        detalleLiquidacion.SubTotal = importeTemp;

                        listDetalleLiquidacion.Add(detalleLiquidacion);
                    }

                    liquidacionGeneral.DetalleLiquidacions = listDetalleLiquidacion;

                    unitOfWork.LiquidacionRepository.Add(liquidacionGeneral);
                    unitOfWork.Save();
                    //return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch{
                
                ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre", liquidacion.EmpresaId);
            }            
            
            return View(liquidacion);
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
                double importeTotal = 0.00;
                foreach(Concepto concepto in listConcepto){
                    switch(concepto.ConceptoId){
                        case 1:
                            importeTotal = importeTotal + (double)concepto.Importe;
                            break;
                        default:
                            importeTotal = calcularSueldo(importeTotal,(double)concepto.Importe,(double)concepto.Porcentaje,(int)concepto.Utilidad,(int)concepto.TipoConceptoId);
                            break;
                    }
                }

                liquidacion.Total = importeTotal;

                double importeTemp = 0.00;
                double sueldoBasico = 0.00;
                foreach(Concepto concepto in listConcepto){
                    DetalleLiquidacion detalleLiquidacion = new DetalleLiquidacion();
                    detalleLiquidacion.ConceptoId = concepto.ConceptoId;
                    importeTemp = 0.00;
                    switch(concepto.ConceptoId){
                        case 1:
                            sueldoBasico = (double)concepto.Importe;
                            importeTemp = sueldoBasico;
                            break;
                        default:
                            importeTemp = calcularSueldo(sueldoBasico, (double)concepto.Importe, (double)concepto.Porcentaje, (int)concepto.Utilidad, (int)concepto.TipoConceptoId);
                            break;
                    }
                    detalleLiquidacion.SubTotal = importeTemp;

                    listDetalleLiquidacion.Add(detalleLiquidacion);
                }

                liquidacion.DetalleLiquidacions = listDetalleLiquidacion;

                unitOfWork.LiquidacionRepository.Add(liquidacion);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre", liquidacion.EmpresaId);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", liquidacion.PersonaId);
            return View(liquidacion);
        }

        public double calcularSueldo(double importeTotal, double importe , double porcentaje, int utilidad, int tipoConceptoId) {
            double importeHaberDebe = 1;
            if (tipoConceptoId == 1)
            {
                importeHaberDebe = importeHaberDebe* 1;
            }
            else {
                importeHaberDebe = importeHaberDebe * -1;
            }

            if (utilidad == 1)
            {
                importeTotal = importeTotal + (importeHaberDebe + importe);
            }
            else { 
                importeTotal = importeTotal + (importeHaberDebe * importeTotal * porcentaje/100.00);
            }
            return importeTotal;
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