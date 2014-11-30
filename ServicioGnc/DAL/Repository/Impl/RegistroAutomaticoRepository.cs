using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL.Repository.Impl
{
    public class RegistroAutomaticoRepository: GenericRepository<ServicioGncContext,RegistroAutomatico>,IRegistroAutomaticoRepository
    {
        public RegistroAutomaticoRepository(ServicioGncContext context) {
            this.Context = context;
        }



        public List<RegistroAutomatico> GetByTurnoEspecial(int id)
        {
            return this.Context.RegistroAutomaticoes.Where(r => r.TurnoEspecialId == id).ToList() ;
        }
    }
}