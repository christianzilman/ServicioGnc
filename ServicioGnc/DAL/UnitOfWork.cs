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
        private GenericRepository<Persona> personaRepository;
        
        public GenericRepository<Persona> PersonaRepository
        {
            get
            {

                if (this.personaRepository == null)
                {
                    this.personaRepository = new GenericRepository<Persona>(context);
                }
                return personaRepository;
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