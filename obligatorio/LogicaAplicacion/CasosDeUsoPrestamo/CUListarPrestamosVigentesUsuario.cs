using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUListarPrestamosVigentesUsuario: ICUListarPrestamosVigentesUsuario
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public CUListarPrestamosVigentesUsuario(IRepositorioPrestamo repoPrestamos) 
        {
            RepoPrestamo = repoPrestamos;
        
        }
        public IEnumerable<DTOListadoPrestamo> Ejecutar(int idUsuario, DateTime fechaActual)
        {
            IEnumerable<Prestamo> pUsuVigentes = RepoPrestamo.FindPrestamosVigentesUsuario(idUsuario, fechaActual);
            return MapperPrestamo.ListPrestamoToDTOListadoPrestamo(pUsuVigentes);
        }

        
    }
}
