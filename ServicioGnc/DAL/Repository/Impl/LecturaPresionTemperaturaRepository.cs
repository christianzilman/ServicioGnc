using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class LecturaPresionTemperaturaRepository:GenericRepository<ServicioGncContext,LecturaPresionTemperatura>,ILecturaPresionTemperaturaRepository
    {
        public LecturaPresionTemperaturaRepository()
        {
            // TODO: Complete member initialization
        }
        public LecturaPresionTemperaturaRepository(ServicioGncContext context)
        {
            // TODO: Complete member initialization
            this.Context = context;
        }
    }
}