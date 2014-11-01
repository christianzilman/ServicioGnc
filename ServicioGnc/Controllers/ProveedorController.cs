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
    public class ProveedorController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Proveedor/

        public ActionResult Index()
        {
            return View(unitOfWork.ProveedorRepository.Get().ToList());
        }

        //
        // GET: /Proveedor/Details/5

        public ActionResult Details(int id = 0)
        {
            Proveedor proveedor = unitOfWork.ProveedorRepository.GetByID(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        //
        // GET: /Proveedor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Proveedor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ProveedorRepository.Add(proveedor);
                unitOfWork.Save();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedor);
        }

        //
        // GET: /Proveedor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Proveedor proveedor = unitOfWork.ProveedorRepository.GetByID(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ProveedorRepository.Edit(proveedor);
                unitOfWork.Save();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        //
        // GET: /Proveedor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Proveedor proveedor = unitOfWork.ProveedorRepository.GetByID(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = unitOfWork.ProveedorRepository.GetByID(id);
            unitOfWork.ProveedorRepository.Delete(proveedor);
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