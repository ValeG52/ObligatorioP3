using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUListadoPrestamo : ICUListadoPrestamo
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public CUListadoPrestamo(IRepositorioPrestamo repoPrestamo)
        {
            RepoPrestamo = repoPrestamo;
        }
        public IEnumerable<DTOListadoPrestamo> Ejecutar()
        {
            IEnumerable<LogicaNegocio.EntidadesNegocio.Prestamo> prestamos = RepoPrestamo.FindAll();
            return Mappers.MapperPrestamo.ListPrestamoToDTOListadoPrestamo(prestamos);
        }
    }
}
