﻿using System;
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
    public class TurnoEspecialController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        //
        // GET: /TurnoEspecial/

        public ActionResult Index()
        {
            var turnoespecials = unitOfWork.TurnoEspecialRepository.Get(includeProperties:"Feriado");
            return View(turnoespecials.ToList());
        }

        //
        // GET: /TurnoEspecial/Details/5
        public ActionResult FeriadosAsignados(string dni, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            var turnosespeciales = unitOfWork.TurnoEspecialRepository.Get();
            if (!String.IsNullOrEmpty(dni) && (fechaDesde != null) && (fechaHasta != null))
            {
                turnosespeciales = turnosespeciales.Where(l => l.Persona.Dni == Convert.ToInt32(dni)).Where((l => Convert.ToDateTime(l.Feriado.Fecha).Date >= Convert.ToDateTime(fechaDesde))).Where((l => Convert.ToDateTime(l.Feriado.Fecha).Date <= Convert.ToDateTime(fechaHasta)));
            }
            else
            {
                if (((fechaDesde != null) && (fechaHasta != null)))
                {
                    turnosespeciales = turnosespeciales.Where((l => Convert.ToDateTime(l.Feriado.Fecha).Date >= Convert.ToDateTime(fechaDesde))).Where((l => Convert.ToDateTime(l.Feriado.Fecha).Date <= Convert.ToDateTime(fechaHasta)));
                }
            }

            ViewBag.Dni = dni;
            ViewBag.FechaDesde = fechaDesde;
            ViewBag.FechaHasta = fechaHasta;


            return View(turnosespeciales.ToList());

        }

        public ActionResult Details(int id = 0)
        {

            TurnoEspecial turnoespecial = unitOfWork.TurnoEspecialRepository.GetByID(id);
            if (turnoespecial == null)
            {
                return HttpNotFound();
            }
            return View(turnoespecial);
        }

        //
        // GET: /TurnoEspecial/Create

        public ActionResult Create()
        {
            ViewBag.FeriadoId = new SelectList(unitOfWork.FeriadoRepository.Get(), "FeriadoId", "Nombre");
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre");
            return View();
        }

        //
        // POST: /TurnoEspecial/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TurnoEspecial turnoespecial)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TurnoEspecialRepository.Add(turnoespecial);
                unitOfWork.TurnoEspecialRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.FeriadoId = new SelectList(unitOfWork.FeriadoRepository.Get(), "FeriadoId", "Nombre", turnoespecial.FeriadoId);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", turnoespecial.PersonaId);
            return View(turnoespecial);
        }

        //
        // GET: /TurnoEspecial/Edit/5

        public ActionResult Edit(int id = 0)
        {

            TurnoEspecial turnoespecial = unitOfWork.TurnoEspecialRepository.GetByID(id);
            if (turnoespecial == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeriadoId = new SelectList(unitOfWork.FeriadoRepository.Get(), "FeriadoId", "Nombre", turnoespecial.FeriadoId);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", turnoespecial.PersonaId);
            return View(turnoespecial);
        }

        //
        // POST: /TurnoEspecial/Edit/5


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TurnoEspecial turnoespecial)
        {
            if (ModelState.IsValid)
            {
                //TurnoEspecial turnoEspecialModificar = unitOfWork.TurnoEspecialRepository.GetByID(turnoespecial.TurnoEspecialId);
                //turnoespecial.FeriadoId = turnoespecial.FeriadoId;
                //turnoespecial.PersonaId = turnoespecial.PersonaId;

                unitOfWork.TurnoEspecialRepository.Edit(turnoespecial);
                
                unitOfWork.TurnoEspecialRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.FeriadoId = new SelectList(unitOfWork.FeriadoRepository.Get(), "FeriadoId", "Nombre", turnoespecial.FeriadoId);
            ViewBag.PersonaId = new SelectList(unitOfWork.PersonaRepository.Get(), "PersonaId", "Nombre", turnoespecial.PersonaId);
            return View(turnoespecial);
        }

        //
        // GET: /TurnoEspecial/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TurnoEspecial turnoespecial = unitOfWork.TurnoEspecialRepository.GetByID(id);
            if (turnoespecial == null)
            {
                return HttpNotFound();
            }
            return View(turnoespecial);
        }

        //
        // POST: /TurnoEspecial/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            List<RegistroAutomatico> listRegistroAutomatico = unitOfWork.RegistroAutomaticoRepository.GetByTurnoEspecial(id);
            foreach(RegistroAutomatico registroAutomatico in listRegistroAutomatico)
            {
                unitOfWork.RegistroAutomaticoRepository.Delete(registroAutomatico);
                unitOfWork.RegistroAutomaticoRepository.Save();
            }

            TurnoEspecial turnoespecial = unitOfWork.TurnoEspecialRepository.GetByID(id);
            unitOfWork.TurnoEspecialRepository.Delete(turnoespecial);
            unitOfWork.TurnoEspecialRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}