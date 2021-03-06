﻿using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioGnc.DAL.Repository
{
    public interface IRegistroAutomaticoRepository: IGenericRepository<RegistroAutomatico>
    {

        List<RegistroAutomatico> GetByTurnoEspecial(int id);
    }
}
