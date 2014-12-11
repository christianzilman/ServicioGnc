using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioGnc.Models;
using ServicioGnc.DAL;
using Rotativa;

namespace ServicioGnc.Controllers
{
    public class LiquidacionController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [Authorize]
        public ActionResult Index(string periodo)
        {
            var liquidacions = unitOfWork.LiquidacionRepository.Get(includeProperties: "Persona");
            if (!String.IsNullOrEmpty(periodo))
            {
            liquidacions = liquidacions.Where(l => l.Periodo.ToUpper().Contains(periodo.ToUpper()));
           
            }
            return View(liquidacions.ToList());
        }


        [Authorize]
        public ActionResult ReportePorEmpleado(string dni/*, string periodo*/)
        {
            var liquidacions = unitOfWork.LiquidacionRepository.Get(includeProperties: "Persona");

            if (!String.IsNullOrEmpty(dni))
            {
                liquidacions = liquidacions.Where(l => l.Persona.Dni == Convert.ToInt32(dni));
            }
            return View(liquidacions.ToList());
        }


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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre");
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            Liquidacion liquidacion = new Liquidacion() { Fecha = DateTime.Now};
            return View(liquidacion);
        }
        [Authorize]
        public ActionResult CreateGeneral()
        {
            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre");
            Liquidacion liquidacion = new Liquidacion() { Fecha = DateTime.Now };
            return View(liquidacion);
        }


        [Authorize]
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
                                importeTemp = sueldoBasico - calcularSueldo(sueldoBasico, (double)concepto.Importe, (double)concepto.Porcentaje, (int)concepto.Utilidad, (int)concepto.TipoConceptoId);
                                break;
                        }
                        detalleLiquidacion.SubTotal = importeTemp;

                        listDetalleLiquidacion.Add(detalleLiquidacion);
                    }

                    liquidacionGeneral.DetalleLiquidacions = listDetalleLiquidacion;

                    unitOfWork.LiquidacionRepository.Add(liquidacionGeneral);
                    unitOfWork.Save();
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
                            importeTemp = sueldoBasico - calcularSueldo(sueldoBasico, (double)concepto.Importe, (double)concepto.Porcentaje, (int)concepto.Utilidad, (int)concepto.TipoConceptoId);
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

        [HttpPost]
        public ActionResult CreateDetail(DetalleLiquidacion detalleLiquidacion)
        {
            double subt = 0.00;
            
            List<DetalleLiquidacion> listDetalleLiquidacion = Session["detalleLiquidacion"] as List<DetalleLiquidacion>;
            int cantidad = listDetalleLiquidacion.Count;
            cantidad++;
            detalleLiquidacion.LiquidacionId = cantidad;

            detalleLiquidacion.Concepto = unitOfWork.ConceptoRepository.GetByID(detalleLiquidacion.ConceptoId);
            Concepto conceptos = unitOfWork.ConceptoRepository.GetByID(1);
            double totDes = (double)conceptos.Importe;

            
            if(detalleLiquidacion.ConceptoId == 1)
            {
                subt = (double)detalleLiquidacion.Concepto.Importe;
            }
            else
            {
                subt = totDes - calcularSueldo(totDes, (double)detalleLiquidacion.Concepto.Importe,(double)detalleLiquidacion.Concepto.Porcentaje,(int)detalleLiquidacion.Concepto.Utilidad,(int)detalleLiquidacion.Concepto.TipoConceptoId);
            }

            detalleLiquidacion.SubTotal = subt;
            
            listDetalleLiquidacion.Add(detalleLiquidacion);

            Session["detalleLiquidacion"] = listDetalleLiquidacion;
            ViewBag.Conceptos = unitOfWork.ConceptoRepository.Get();
           
            return View();
        }

        [HttpPost]
        public ActionResult DeleteDetail(int ConceptoId)
        {
            List<DetalleLiquidacion> listDetalleLiquidacion = Session["detalleLiquidacion"] as List<DetalleLiquidacion>;

            DetalleLiquidacion temp = null;
            foreach (DetalleLiquidacion item in listDetalleLiquidacion)
            {
                if (item.ConceptoId == ConceptoId)
                {
                    temp = item;
                }
            }

            if (temp != null)
            {
                listDetalleLiquidacion.Remove(temp);
            }


            Session["detalleLiquidacion"] = listDetalleLiquidacion;
            ViewBag.DetalleLiquidacion = listDetalleLiquidacion;

            return View("ListDetail");
        }

        [HttpPost]
        public ActionResult ListDetail()
        {
            ViewBag.DetalleLiquidacion = Session["detalleLiquidacion"] as List<DetalleLiquidacion>;

            return View();
        }

        public ActionResult CreateParticular()
        {
            Session["detalleLiquidacion"] = new List<DetalleLiquidacion>();
            ViewBag.Conceptos = unitOfWork.ConceptoRepository.Get();
            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre");
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            Liquidacion liquidacion = new Liquidacion() { Fecha = DateTime.Now };
            return View(liquidacion);
        }

        //
        // POST: /Turno/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateParticular(Liquidacion liquidacion)
        {
            if (ModelState.IsValid)
            {
                liquidacion.DetalleLiquidacions = Session["detalleLiquidacion"] as List<DetalleLiquidacion>;
                Session["detalleLiquidacion"] = new List<DetalleLiquidacion>();
                double importeTotal = 0.00;
                foreach (DetalleLiquidacion detalleconcepto in liquidacion.DetalleLiquidacions)
                {
                    switch ( detalleconcepto.ConceptoId)
                    {
                        case 1:
                            importeTotal = importeTotal + (double)detalleconcepto.Concepto.Importe;
                            break;
                        default:
                            importeTotal = calcularSueldo(importeTotal, (double)detalleconcepto.Concepto.Importe, (double)detalleconcepto.Concepto.Porcentaje, (int)detalleconcepto.Concepto.Utilidad, (int)detalleconcepto.Concepto.TipoConceptoId);
                            break;
                    }
                    detalleconcepto.Concepto = null;
                }
                liquidacion.Fecha = DateTime.Today;
                liquidacion.Total = importeTotal;                
                unitOfWork.LiquidacionRepository.Add(liquidacion);
                unitOfWork.LiquidacionRepository.Save();
                return new ActionAsPdf(
                                        "ImprimirLiquidacion",
                                        new { LiquidacionId = liquidacion.LiquidacionId }
                                        );
            }

            ViewBag.EmpresaId = new SelectList(unitOfWork.EmpresaRepository.Get(), "EmpresaId", "Nombre");
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            return View(liquidacion);
        }

        public ActionResult ImprimirLiquidacion(int LiquidacionId)
        {
            Liquidacion liquidacion = unitOfWork.LiquidacionRepository.GetByID(LiquidacionId);
            ViewBag.Liquidacion = unitOfWork.LiquidacionRepository.GetByID(LiquidacionId);
            ViewBag.DetalleLiquidacion = liquidacion.DetalleLiquidacions;
            return View(liquidacion);
        }




        public ActionResult Impresiones(int id)
        {
            Liquidacion liquidacion = unitOfWork.LiquidacionRepository.GetByID(id);
            return new ActionAsPdf(
                                        "ImprimirLiquidacion",
                                        new { LiquidacionId = liquidacion.LiquidacionId }
                                        );
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}