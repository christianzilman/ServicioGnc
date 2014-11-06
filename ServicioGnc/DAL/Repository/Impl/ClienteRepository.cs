using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class ClienteRepository :
    GenericRepository<ServicioGncContext, Cliente>, IClienteRepository 
    {
        public ClienteRepository() { }
        public ClienteRepository(ServicioGncContext context)
        {
            this.Context = context;
        }
    }
}