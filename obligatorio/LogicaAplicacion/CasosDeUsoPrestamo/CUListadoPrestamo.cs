using System;
using System.Collections.Generic;
using System.Text;
using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUListadoPrestamo : ICUListadoPrestamo
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public CUListadoPrestamo(IRepositorioPrestamo repoPrestamo)
        {
            RepoPrestamo = repoPrestamo;
        }
        public IEnumerable<DTOListadoPrestamo> Ejecutar(int id)
        {
            IEnumerable<Prestamo> prestamos = RepoPrestamo.FindPrestamosUsuario(id);
            return MapperPrestamo.ListPrestamoToDTOListadoPrestamo(prestamos);
        }
    }
}
