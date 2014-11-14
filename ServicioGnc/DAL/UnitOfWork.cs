﻿using ServicioGnc.DAL.Repository;
using ServicioGnc.DAL.Repository.Impl;
using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioGnc.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ServicioGncContext context = new ServicioGncContext();
        private IPersonaRepository personaRepository;
        private IProveedorRepository proveedorRepository;
        private IProductoRepository productoRepository;
        private IUnidadRepository unidadRepository;
        private ICarroRepository carroRepository;
        private IVentaRepository ventaRepository;
        private ICompraRepository compraRepository;
        private IClienteRepository clienteRepository;
        private ILiquidacionRepository liquidacionRepository;
        private IEmpresaRepository empresaRepository;
        private IConceptoRepository conceptoRepository;
        private ITipoConcepto tipoConceptoRepository;
        private IFichadaRepository fichadaRepository;
        private ILecturaPresionTemperaturaRepository lecturaPresionTemperaturaRepository;
        private IFeriadoRepository feriadoRepository;
        private ITurnoRepository turnoRepository;
        private ITurnoEspecialRepository turnoEspecialRepository;

        public ITurnoEspecialRepository TurnoEspecialRepository {
            get
            {
                if(this.turnoEspecialRepository==null){
                    this.turnoEspecialRepository = new TurnoEspecialRepository(context);
                }
                return this.turnoEspecialRepository;
            }
        }

        public ITurnoRepository TurnoRepository
        {
            get
            {
                if (this.turnoRepository == null)
                {
                    this.turnoRepository = new TurnoRepository(context);
                }
                return this.turnoRepository;
            }
        }

        public IFeriadoRepository FeriadoRepository
        {
            get
            {
                if (this.feriadoRepository == null)
                {
                    this.feriadoRepository = new FeriadoRepository(context);
                }
                return this.feriadoRepository;
            }
        }
        public ILecturaPresionTemperaturaRepository LecturaPresionTemperaturaRepository
        {
            get
            {
                if (this.lecturaPresionTemperaturaRepository == null)
                {
                    this.lecturaPresionTemperaturaRepository = new LecturaPresionTemperaturaRepository(context);
                }
                return this.lecturaPresionTemperaturaRepository;
            }
        }

        public IFichadaRepository FichadaRepository
        {
            get 
            {
                if (this.fichadaRepository == null)
                {
                    this.fichadaRepository = new FichadaRepository(context);
                }
                return this.fichadaRepository;
            }        
        }

        public  ITipoConcepto TipoConceptoRepository
        {
            get
            {
                if (this.tipoConceptoRepository == null)
                {
                    this.tipoConceptoRepository = new TipoConceptoRepository(context);                
                }
                return this.tipoConceptoRepository;
            }
        }
        public IConceptoRepository ConceptoRepository
        {
            get
            {
                if (this.conceptoRepository == null)
                {
                    this.conceptoRepository = new ConceptoRepository(context);
                }
                return this.conceptoRepository;
            }  

        }

        public IEmpresaRepository EmpresaRepository
        {
            get
            {
                if(this.empresaRepository==null){
                    this.empresaRepository = new EmpresaRepository(context);
                }
                return this.empresaRepository;
            }
        }

        public ILiquidacionRepository LiquidacionRepository
        {
            get
            {
                if(this.liquidacionRepository==null)
                {
                    this.liquidacionRepository = new LiquidacionRepository(context);
                }
                return this.liquidacionRepository;
            }
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                if (this.clienteRepository == null)
                {
                    this.clienteRepository = new ClienteRepository(context);
                }
                return clienteRepository;
            }
        }

        public ICompraRepository CompraRepository
        {
            get
            {
                if (this.compraRepository == null)
                {
                    this.compraRepository = new CompraRepository(context);
                }
                return compraRepository;
            }
        }

        public IVentaRepository VentaRepository
        {
            get{
                if(this.ventaRepository==null){
                    this.ventaRepository = new VentaRepository(context);
                }
                return ventaRepository;
            }
        }

        public ICarroRepository CarroRepository {
            get
            {
                if(this.carroRepository== null){
                    this.carroRepository = new CarroRepository(context);
                }
                return this.carroRepository;
            }
        }

        public IUnidadRepository UnidadRepository {
            get {
                if(this.unidadRepository==null){
                    this.unidadRepository = new UnidadRepository(context);
                }
                return this.unidadRepository;
            }
        }

        public IProductoRepository ProductoRepository
        {
            get 
            {
                if(this.productoRepository==null){
                    this.productoRepository = new ProductoRepository(context);
                }
                return this.productoRepository;
            }        
        }

        public IPersonaRepository PersonaRepository
        {
            get
            {

                if (this.personaRepository == null)
                {
                    this.personaRepository =  new PersonaRepository(context); //new GenericRepository<Persona>(context);
                }
                return this.personaRepository;
            }
        }

        public IProveedorRepository ProveedorRepository {
            get { 
                if(this.proveedorRepository==null){
                    this.proveedorRepository = new ProveedorRepository(context);
                }
                return this.proveedorRepository;
            }        
        }




        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}