using ServicioGnc.DAL.Repository;
using ServicioGnc.DAL.Repository.Impl;
using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ServicioGncContext context = new ServicioGncContext();
        private IPersonaRepository personaRepository;
        private IProveedorRepository proveedorRepository;
        private IProductoRepository productoRepository;
        private IUnidadRepository unidadRepository;

        public IUnidadRepository UnidadRepository {
            get {
                if(this.unidadRepository==null){
                    this.unidadRepository = new UnidadRepository(context);
                }
                return this.unidadRepository;
            }
        }

        public IProductoRepository ProductoRepository
        {
            get 
            {
                if(this.productoRepository==null){
                    this.productoRepository = new ProductoRepository(context);
                }
                return this.productoRepository;
            }        
        }

        public IPersonaRepository PersonaRepository
        {
            get
            {

                if (this.personaRepository == null)
                {
                    this.personaRepository =  new PersonaRepository(context); //new GenericRepository<Persona>(context);
                }
                return this.personaRepository;
            }
        }

        public IProveedorRepository ProveedorRepository {
            get { 
                if(this.proveedorRepository==null){
                    this.proveedorRepository = new ProveedorRepository(context);
                }
                return this.proveedorRepository;
            }        
        }




        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}