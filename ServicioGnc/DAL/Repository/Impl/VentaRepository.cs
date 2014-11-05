using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class VentaRepository:GenericRepository<ServicioGncContext,Venta>,IVentaRepository
    {
        public VentaRepository(){}

        public VentaRepository(ServicioGncContext context){
            this.Context = context;
        }
    }
}