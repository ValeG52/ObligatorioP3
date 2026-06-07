using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUListadoPrestamosEntreFechas : ICUListadoPrestamosEntreFechas
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public CUListadoPrestamosEntreFechas(IRepositorioPrestamo repoPrestamo)
        {
            RepoPrestamo = repoPrestamo;
        }
        public IEnumerable<DTOListadoPrestamo> Ejecutar (int idUsuario , int mes , int anio)
        {
            IEnumerable<Prestamo> pBuscados = RepoPrestamo.FindPrestamosMesAnioUsuario(idUsuario, mes, anio);
            
            return Mappers.MapperPrestamo.ListPrestamoToDTOListadoPrestamo(pBuscados);
        }
    }
}
