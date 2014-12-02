﻿using ServicioGnc.Models;
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


    }
}