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
                Estado = a.Estado.ToString(),
                Atrasado = a.Estado == Estado.EnPrestamo && a.Fin < DateTime.Now //Atrasado es verdadero si: el estado es EnPrestamo y la fecha fin ya pasó
            }).ToList();
            return listprestamos;

        }
        public static DTOPrestamo PrestamoToDTOPrestamo(Prestamo prestamo)
        {
            DTOPrestamo creado = new DTOPrestamo();
            creado.Id = prestamo.Id;
            creado.Inicio = prestamo.Inicio;
            creado.Fin = prestamo.Fin;
            creado.UsuarioId = prestamo.Usuario.Id;
            creado.CamaraId = prestamo.Equipos.OfType<Camara>().FirstOrDefault()?.Id;
            creado.MonturaId = prestamo.Equipos.OfType<Montura>().FirstOrDefault().Id;
            creado.TelescopioId = prestamo.Equipos.OfType<Telescopio>().FirstOrDefault().Id;
            creado.OcularId = prestamo.Equipos.OfType<Ocular>().FirstOrDefault()?.Id;
            creado.Estado = prestamo.Estado;

            return creado;
        }
    }
    
}
