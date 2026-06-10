using CasosDeUso.DTOs.DTOPrestamos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUBuscarPrestamo : ICUBuscarPrestamo
    {
        public IRepositorioPrestamo RepoPrestamo    { get; set; }
        public CUBuscarPrestamo(IRepositorioPrestamo repoPrestamo)
        {
            RepoPrestamo = repoPrestamo;
        }
        public DTOPrestamo Ejecutar(int id)
        {
            Prestamo prestamo = RepoPrestamo.FindById(id);
            return Mappers.MapperPrestamo.PrestamoToDTOPrestamo(prestamo);
        }
    }
}
