using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class TurnoEspecialRepository:GenericRepository<ServicioGncContext,TurnoEspecial>,ITurnoEspecialRepository
    {
        public TurnoEspecialRepository() { }
        public TurnoEspecialRepository(ServicioGncContext context) 
        {
            this.Context = context;
        }
    }
}