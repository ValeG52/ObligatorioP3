using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InteracesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using CasosDeUso.DTOs.DTOPrestamos;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUAltaPrestamo : ICUAltaPrestamo
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public CUAltaPrestamo (IRepositorioPrestamo repo)
        {
            RepoPrestamo = repo;
        }
        public void Ejecutar (DTOPrestamo dtoPrestamo)
        {
            Prestamo prestamo = MapperPrestamo.DTOPrestamoToPrestamo(dtoPrestamo);
            RepoPrestamo.Add(prestamo);
        }
    }
}
