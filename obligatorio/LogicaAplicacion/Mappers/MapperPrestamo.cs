using CasosDeUso.DTOs.DTOPrestamos;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.ValueObject;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.Mappers
{
    public class MapperPrestamo
    {
        
        public Prestamo DTOPrestamoToPrestamo(DTOPrestamo dtoPrestamo)
        {
            if (dtoPrestamo == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            
            return new Prestamo()
            {
                Inicio = dtoPrestamo.Inicio,
                Fin = dtoPrestamo.Fin,
                Usuario = dtoPrestamo.Usuario,
               // Equipos = dtoPrestamo.EquiposIds.Select(id => RepositorioPrestamoEF.FindById(id)).ToList(),
                Estado = dtoPrestamo.Estado,
                
            };
        }
    }
    
}
