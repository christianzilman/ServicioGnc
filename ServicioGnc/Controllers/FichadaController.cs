using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioGnc.DAL;
using ServicioGnc.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace ServicioGnc.Controllers
{
    public class FichadaController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        //
        // GET: /Fichada/

        public ActionResult Index()
        {
            //var fichadas = unitOfWork.FichadaRepository.Get();
            //return View(fichadas.ToList());
            return View();
        }

        public ActionResult Consulta()
        {
            var fichadas = unitOfWork.FichadaRepository.Get();
            return View(fichadas.ToList());
            //return View();
        }

        public ActionResult FichadaPorEmpleado(string dni, string fechaDesde,string fechaHasta)
        {
            var fichadas = unitOfWork.FichadaRepository.Get();
            //fechaDesde
            if (!String.IsNullOrEmpty(dni))
            {
                fichadas = fichadas.Where(l => l.Persona.Dni == Convert.ToInt32(dni)).Where((l => Convert.ToDateTime(l.FechaIngreso).Date >= Convert.ToDateTime(fechaDesde))).Where((l => Convert.ToDateTime(l.FechaEgreso).Date <= Convert.ToDateTime(fechaHasta)));
            }
            return View(fichadas.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension =
                                     System.IO.Path.GetExtension(Request.Files["file"].FileName);

                // work out where we should split on comma, but not in a sentence
                Regex r = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                StreamReader sr =  new StreamReader(Request.Files["file"].InputStream);

                string line = string.Empty;
                string[] strArray;
                //Read the first line and split the string at , with our regular expression in to an array
                line = sr.ReadLine();
                strArray = r.Split(line);

                
                //Read each line in the CVS file until it’s empty
                while ((line = sr.ReadLine()) != null)
                {
                    strArray = line.Split(',');
                    Fichada fichada = new Fichada();

                    int DiaIngreso = 0;
                    int MesIngreso = 0;
                    int AñoIngreso = 0;
                    int HoraIngreso = 0;
                    int MinutoIngreso = 0;

                    int DiaEgreso = 0;
                    int MesEgreso = 0;
                    int AñoEgreso = 0;
                    int HoraEgreso = 0;
                    int MinutoEgreso = 0;

                    for (int i = 0; i < strArray.Count();i++ )
                    {
                        if(i==0){
                            String [] fechaI = strArray[i].Split('/');
                            DiaIngreso = Convert.ToInt32(fechaI[0]);
                            MesIngreso = Convert.ToInt32(fechaI[1]);
                            AñoIngreso = Convert.ToInt32(fechaI[2]);
                        }
                        if(i==1){
                            String[] horaI = strArray[i].Split(':');
                            HoraIngreso = Convert.ToInt32(horaI[0]);
                            MinutoIngreso = Convert.ToInt32(horaI[1]);
                        }

                        if (i == 2)
                        {
                            String[] fechaE = strArray[i].Split('/');
                            DiaEgreso = Convert.ToInt32(fechaE[0]);
                            MesEgreso = Convert.ToInt32(fechaE[1]);
                            AñoEgreso = Convert.ToInt32(fechaE[2]);
                        }
                        if (i == 3)
                        {
                            String[] horaE = strArray[i].Split(':');
                            HoraEgreso = Convert.ToInt32(horaE[0]);
                            MinutoEgreso = Convert.ToInt32(horaE[1]);
                        }
                        if (i == 4)
                        {
                            fichada.PersonaId = Convert.ToInt32(strArray[i]);
                        }

                        if (i == 5)
                        {
                            fichada.Observacion = strArray[i];
                        }
                    }

                    DateTime fechaIngresoCompleta = new DateTime(AñoIngreso, MesIngreso, DiaIngreso, HoraIngreso, MinutoIngreso, 0);
                    DateTime fechaEgresoCompleta = new DateTime(AñoEgreso, MesEgreso, DiaEgreso, HoraEgreso, MinutoEgreso, 0);

                    fichada.FechaIngreso = fechaIngresoCompleta;
                    fichada.FechaEgreso = fechaEgresoCompleta;
                    unitOfWork.FichadaRepository.Add(fichada);
                    unitOfWork.Save();
                    //Console.WriteLine(line);
                }
                //Tidy Streameader up
                sr.Dispose();
            }
            return View("CargaExitosa");
        }

        public ActionResult CargaExitosa()
        {
            var fichadas = unitOfWork.FichadaRepository.Get();
            return View(fichadas.ToList());
            
        }

        //
        // GET: /Fichada/Details/5

        public ActionResult Details(int id = 0)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            if (fichada == null)
            {
                return HttpNotFound();
            }
            return View(fichada);
        }

        //
        // GET: /Fichada/Create

        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            return View();
        }

        //
        // POST: /Fichada/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fichada fichada)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FichadaRepository.Add(fichada);
                unitOfWork.FichadaRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", fichada.PersonaId);
            return View(fichada);
        }

        //
        // GET: /Fichada/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            if (fichada == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", fichada.PersonaId);
            return View(fichada);
        }

        //
        // POST: /Fichada/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fichada fichada)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FichadaRepository.Edit(fichada);
                unitOfWork.FichadaRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", fichada.PersonaId);
            return View(fichada);
        }

        //
        // GET: /Fichada/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            if (fichada == null)
            {
                return HttpNotFound();
            }
            return View(fichada);
        }

        //
        // POST: /Fichada/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fichada fichada = unitOfWork.FichadaRepository.GetByID(id);
            unitOfWork.FichadaRepository.Delete(fichada);
            unitOfWork.FichadaRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}