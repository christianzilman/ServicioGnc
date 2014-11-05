using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class CompraRepository:GenericRepository<ServicioGncContext,Compra>,ICompraRepository
    {
        public CompraRepository(){}

        public CompraRepository(ServicioGncContext context){
            this.Context = context;
        }
    }
}