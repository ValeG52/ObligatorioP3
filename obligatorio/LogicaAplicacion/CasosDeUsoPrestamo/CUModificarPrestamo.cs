using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using ExcepcionesPropias;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUModificarPrestamo : ICUModificarPrestamo
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public CUModificarPrestamo (IRepositorioPrestamo repoPrestamo)
        {
            RepoPrestamo = repoPrestamo;
        }
        public void Ejecutar(int id)
        {
            if (id > 0)
            {

                Prestamo pBuscado = RepoPrestamo.FindById(id);
                
                RepoPrestamo.Update(id, pBuscado);
            }
            else
            {
                throw new DatosInvalidosException("El id no es correcto");

            }
        }
    }
}
