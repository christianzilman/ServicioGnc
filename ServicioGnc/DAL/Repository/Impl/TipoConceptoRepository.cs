using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class TipoConceptoRepository:GenericRepository<ServicioGncContext,TipoConcepto>,ITipoConcepto
    {
        public TipoConceptoRepository() 
        { 
        }
        public TipoConceptoRepository(ServicioGncContext context)
        {
            this.Context = context;
        }

    }
}