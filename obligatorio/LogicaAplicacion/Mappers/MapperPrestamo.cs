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
        
        public static Prestamo DTOPrestamoToPrestamo(DTOPrestamo dtoPrestamo, List<Equipo> equipos, Usuario usu)
        {
            if (dtoPrestamo == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            
            return new Prestamo()
            {
                Inicio = dtoPrestamo.Inicio,
                Fin = dtoPrestamo.Fin,
                Usuario = usu,
                Equipos = equipos,
                Estado = dtoPrestamo.Estado,
                
            };
        }
    }
    
}
