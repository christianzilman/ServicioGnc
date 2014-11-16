using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class CarroRepository:GenericRepository<ServicioGncContext,Carro>,ICarroRepository
    {
        public CarroRepository(){
        }

        public CarroRepository(ServicioGncContext context)
        {
            this.Context = context;
        }

        public List<Carro> GetByTipoOperacion(int TipoOperacionId)
        {
            return this.Context.Set<Carro>().Include("Producto").Where(c => c.TipoOperacionId == TipoOperacionId).ToList();
        }
    }
}