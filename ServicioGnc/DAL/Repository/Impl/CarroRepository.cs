﻿using ServicioGnc.Models;
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
    }
}