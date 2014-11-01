using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class ProveedorRepository:GenericRepository<ServicioGncContext,Proveedor>,IProveedorRepository
    {
        public ProveedorRepository()
        {
            // TODO: Complete member initialization
        }
        public ProveedorRepository(ServicioGncContext context)
        {
            // TODO: Complete member initialization
            this.Context = context;
        }
    }
}