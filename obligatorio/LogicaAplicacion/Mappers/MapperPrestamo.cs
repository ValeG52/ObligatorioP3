using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOPrestamos;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
using LogicaNegocio.ValueObject;
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

        public static List<DTOListadoPrestamo> ListPrestamoToDTOListadoPrestamo(IEnumerable<Prestamo> prestamos)
        {

            List<DTOListadoPrestamo> listprestamos = new List<DTOListadoPrestamo>();
            listprestamos = prestamos.Select(a => new DTOListadoPrestamo()
            {
                Id = a.Id,
                Inicio = a.Inicio,
                Fin = a.Fin,
                Estado = a.GetType().Name,
            }).ToList();
            return listprestamos;

        }
    }
    
}
