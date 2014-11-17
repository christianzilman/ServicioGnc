using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class TipoEstadoRepository:GenericRepository<ServicioGncContext,TipoEstado>,ITipoEstadoRepository
    {
        public TipoEstadoRepository() { }
        public TipoEstadoRepository(ServicioGncContext context) 
        {
            this.Context = context;
        }
    }
}