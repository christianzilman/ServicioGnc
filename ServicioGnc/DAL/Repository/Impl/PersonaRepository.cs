using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class PersonaRepository :
    GenericRepository<ServicioGncContext, Persona>, IPersonaRepository 
    {
        public PersonaRepository() { }
        public PersonaRepository(ServicioGncContext context)
        {
            this.Context = context;
        }
    }
}