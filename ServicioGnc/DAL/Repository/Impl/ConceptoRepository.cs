using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class ConceptoRepository:GenericRepository<ServicioGncContext,Concepto>,IConceptoRepository
    {
        public ConceptoRepository()
        {

        }

        public ConceptoRepository(ServicioGncContext context)
        {
            this.Context = context;
        }
    }
}