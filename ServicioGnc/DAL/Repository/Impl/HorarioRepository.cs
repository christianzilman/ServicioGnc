using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class HorarioRepository:GenericRepository<ServicioGncContext,Horario>,IHorarioRepository
    {
        public HorarioRepository() { 
        }

        public HorarioRepository(ServicioGncContext context) {
            this.Context = context;
        }
    }
}