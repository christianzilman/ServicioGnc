using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class FamiliarRepository:GenericRepository<ServicioGncContext, Familiar>,IFamiliarRepository
    {
        public FamiliarRepository() { }
        public FamiliarRepository(ServicioGncContext context)
        {
            this.Context = context;
        }
    }
}