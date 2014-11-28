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
            ViewBag.Mensaje = "";
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

            Feriado feriado = null;

            for(int i=0; i<1 && listFeriado.Count>0; i++){
                feriado = listFeriado[0];
            }
            
            if(feriado!=null){
                // Si hay turnos especiales en ese feriado ya no debe asignar dinamicamente el feriado a empleados
                List<TurnoEspecial> listTurnoEspecial = unitOfWork.TurnoEspecialRepository.GetByFeriado(feriado.FeriadoId);

                int cantidadTurnos = listTurnoEspecial.Count;
                


                if(listTurnoEspecial==null || listTurnoEspecial.Count==0){
                    // me fijo en configuración que cantidad de empleados asignaremos los o el feriado
                    // hace falta la tabla de registro automatico para que no le asigne dinamicamente los feriados reiteradas veces
                    List<Persona> listPersonas = unitOfWork.PersonaRepository.GetAll().ToList();

                    Configuracion configuracion = unitOfWork.ConfiguracionRepository.GetByID(1);

                    int cantidadPersonas = listPersonas.Count;

                    Random random = new Random();
                    int personaR;
                    
                    List<int> listPersonaId = new List<int>();
                    List<Persona> listPersonasTomadas = new List<Persona>();
                    // {}
                    for(int i = 0 ; i < configuracion.CantidadEmpleado; i++)
                    {
                        do
                        {
                            personaR = random.Next(0, cantidadPersonas);
                            if(!listPersonaId.Contains(personaR))
                            {
                                listPersonaId.Add(personaR);
                                listPersonasTomadas.Add(listPersonas[personaR]);
                                break;
                            }                         
                        }
                        while(true);
                    }




                    
                    //Feriado feriado1 = unitOfWork.FeriadoRepository.GetByID(turnoR);
                    List<TurnoEspecial> listTurnoEspecialAgregado = new List<TurnoEspecial>();

                    foreach(Persona persona in listPersonasTomadas){
                        TurnoEspecial turnoEspecial = new TurnoEspecial();
                        turnoEspecial.FeriadoId = feriado.FeriadoId;
                        turnoEspecial.PersonaId = persona.PersonaId;
                        
                        unitOfWork.TurnoEspecialRepository.Add(turnoEspecial);
                        unitOfWork.Save();

                        listTurnoEspecialAgregado.Add(turnoEspecial);
                    }

                    foreach(TurnoEspecial turnoEspecial in listTurnoEspecialAgregado){                        
                        RegistroAutomatico registroAutomatico = new RegistroAutomatico();
                        registroAutomatico.Fecha = DateTime.Now;
                        registroAutomatico.TurnoEspecialId = turnoEspecial.TurnoEspecialId;
                        unitOfWork.RegistroAutomaticoRepository.Add(registroAutomatico);
                        unitOfWork.Save();
                    }

                    // hacer el random aleatorio de la cantidad de empleados y eligir uno y preguntar si esta de forma consecutiva en la 
                    // tabla registro automatico


                    // despues elegir los empleados realizar el insert en turno espoeciales y con eso quedaría retornar el index
                    return View("Exito");

                }
            }else{
                ViewBag.Mensaje = " La asignación automatica ya ha sido utilizada ";
            }

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