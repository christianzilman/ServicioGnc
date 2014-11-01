using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class ProductoRepository:GenericRepository<ServicioGncContext,Producto>,IProductoRepository
    {
        public ProductoRepository() { }
        public ProductoRepository(ServicioGncContext context) {
            this.Context = context;
        }
    }
}