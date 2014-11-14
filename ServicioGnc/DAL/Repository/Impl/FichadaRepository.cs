using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class FichadaRepository :  GenericRepository<ServicioGncContext, Fichada>, IFichadaRepository
    {
        public FichadaRepository() { }
        public FichadaRepository(ServicioGncContext context)
        {
            this.Context = context;
        }
    }
}