using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class EmpresaRepository:GenericRepository<ServicioGncContext,Empresa>,IEmpresaRepository
    {
        public EmpresaRepository() { }

        public EmpresaRepository(ServicioGncContext context) {
            this.Context = context;
        }
    }
}