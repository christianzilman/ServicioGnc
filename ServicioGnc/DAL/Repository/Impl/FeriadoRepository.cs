using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class FeriadoRepository:GenericRepository<ServicioGncContext,Feriado>,IFeriadoRepository
    {
        public FeriadoRepository() { }

        public FeriadoRepository(ServicioGncContext context)
        {
            this.Context = context;
        }

        public List<Feriado> GetByGreaterThanDate(DateTime fechaActual)
        {
            throw new NotImplementedException();
        }
    }
}