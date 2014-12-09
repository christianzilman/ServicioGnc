using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioGnc.Models;
using ServicioGnc.DAL;
using WebMatrix.WebData;

namespace ServicioGnc.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Personal/

        public ActionResult Index()
        {
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            //includeProperties: "Persona"
            var personaList = unitOfWork.PersonaRepository.Get();
            return View(personaList.ToList());
        }

        //
        // GET: /Personal/Details/5

        public ActionResult Details(int id = 0)
        {
            Persona persona = unitOfWork.PersonaRepository.GetByID(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }


        //[HttpPost]
        //public ActionResult BuscarPersona(int dni)
        //{
        //    Persona persona = unitOfWork.PersonaRepository.GetByIDDni(dni);
        //    Producto producto = unitOfWork.ProductoRepository.GetByID(productoId);
        //    ViewBag.ProductoId = productoId;
        //    ViewBag.NombreProducto = producto.Nombre;
        //    ViewBag.PrecioCompra = producto.PrecioCompra;
        //    return View();

        //}


        //
        // GET: /Personal/Create

        public ActionResult Create()
        {
            return View(new Persona());
        }

        //
        // POST: /Personal/Create

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PersonaRepository.Add(persona);
                unitOfWork.PersonaRepository.Save();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        //
        // GET: /Personal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persona persona = unitOfWork.PersonaRepository.GetByID(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Personal/Edit/5

        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PersonaRepository.Edit(persona);
                unitOfWork.PersonaRepository.Save();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        //
        // GET: /Personal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persona persona = unitOfWork.PersonaRepository.GetByID(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Personal/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = unitOfWork.PersonaRepository.GetByID(id);
            unitOfWork.PersonaRepository.Delete(persona);
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