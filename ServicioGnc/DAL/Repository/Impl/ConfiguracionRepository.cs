using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class ConfiguracionRepository:GenericRepository<ServicioGncContext,Configuracion>,IConfiguracionRepository
    {
        public ConfiguracionRepository(ServicioGncContext context) {
            this.Context = context;
        }
    }
}