using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class TurnoRepository:GenericRepository<ServicioGncContext,Turno>,ITurnoRepository
    {
        public TurnoRepository()
        {
            // TODO: Complete member initialization
        }
        public TurnoRepository(ServicioGncContext context)
        {
            // TODO: Complete member initialization
            this.Context = context;
        }
    }
}