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
            return this.Context.Feriadoes.Where(f => f.Fecha > fechaActual).OrderBy(f => f.Fecha).ToList<Feriado>();
        }
    }
}