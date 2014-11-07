using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class LiquidacionRepository : GenericRepository<ServicioGncContext, Liquidacion>, ILiquidacionRepository
    {
        public LiquidacionRepository()
        {

        }

        public LiquidacionRepository(ServicioGncContext context){
            this.Context = context;        
        }

    }
}