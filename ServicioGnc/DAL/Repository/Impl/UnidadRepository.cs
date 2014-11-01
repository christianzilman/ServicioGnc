using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class UnidadRepository: GenericRepository<ServicioGncContext,Unidad>, IUnidadRepository
    {
        public UnidadRepository() { }
        public UnidadRepository(ServicioGncContext context) {
            this.Context = context;
        }
    }
}