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
    public class CompraController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Compra/

        public ActionResult Index()
        {
            var compras = unitOfWork.CompraRepository.Get(includeProperties: "Proveedor").Where(t => t.TipoEstadoId < 3 );
            return View(compras.ToList());
        }

        //
        // GET: /Compra/Details/5

        public ActionResult Details(int id = 0)
        {
            Compra compra = unitOfWork.CompraRepository.GetByID(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        //
        // GET: /Compra/Create

        public ActionResult Create()
        {
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "RazonSocial");
            return View();
        }

        //
        // POST: /Compra/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compra compra)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CompraRepository.Add(compra);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "RazonSocial", compra.ProveedorId);
            return View(compra);
        }

        //
        // GET: /Compra/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Compra compra = unitOfWork.CompraRepository.GetByID(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "RazonSocial", compra.ProveedorId);
            ViewBag.TipoEstadoId = new SelectList(unitOfWork.TipoEstadoRepository.Get().Where(t => t.TipoEstadoId > 1 && t.TipoEstadoId < 4), "TipoEstadoId", "Nombre", compra.TipoEstadoId);
            return View(compra);
        }

        //
        // POST: /Compra/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Compra compra)
        {
            if (ModelState.IsValid)
            {
                Compra compraCompleta = unitOfWork.CompraRepository.GetByID(compra.CompraId);
                if (compra.TipoEstadoId == 2 || compra.TipoEstadoId == 4) {
                    List<DetalleCompra> listDetalleCompra = unitOfWork.DetalleCompraRepository.GetByCompra(compra.CompraId);
                    foreach (DetalleCompra detalle in listDetalleCompra)
                    {
                        Producto producto = unitOfWork.ProductoRepository.GetByID(detalle.ProductoId);
                        producto.Cantidad = producto.Cantidad + detalle.Cantidad;
                        unitOfWork.ProductoRepository.Edit(producto);
                    }
                }
                compraCompleta.TipoEstadoId = compra.TipoEstadoId;
                compraCompleta.Fecha = compra.Fecha;
                compraCompleta.ProveedorId = compra.ProveedorId;

                unitOfWork.CompraRepository.Edit(compraCompleta);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedorId = new SelectList(unitOfWork.ProveedorRepository.Get(), "ProveedorId", "RazonSocial", compra.ProveedorId);
            ViewBag.TipoEstadoId = new SelectList(unitOfWork.TipoEstadoRepository.Get().Where(t => t.TipoEstadoId > 1 && t.TipoEstadoId < 4), "TipoEstadoId", "Nombre", compra.TipoEstadoId);
            return View(compra);
        }

        //
        // GET: /Compra/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Compra compra = unitOfWork.CompraRepository.GetByID(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        //
        // POST: /Compra/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = unitOfWork.CompraRepository.GetByID(id);
            unitOfWork.CompraRepository.Delete(compra);
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