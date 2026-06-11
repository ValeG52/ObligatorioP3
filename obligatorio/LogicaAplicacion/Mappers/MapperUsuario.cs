using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOUsuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.Mappers
{
    public class MapperUsuario
    {
        public static Usuario UsuarioDTOUsuarioToUsuario(DTOUsuario dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("Los datos no son correctos.");
            }

            return new Usuario
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = dto.Email,
                NombreUsu = dto.NombreUsu,
                Contrasenia = new ContraseniaVO(dto.Contrasenia),
                Rol = dto.Rol
            };
        }
        public static List<DTOListadoUsuario> ListUsuarosToDTOListadoUsuarios(IEnumerable<Usuario> usu)
        {

            List<DTOListadoUsuario> lista = new List<DTOListadoUsuario>();
            lista = usu.Select(a => new DTOListadoUsuario()
            {
                Id = a.Id,
                Nombre = a.Nombre,
            }).ToList();
            return lista;

        }
        public static  IEnumerable<DTOCoordinador> ListCoordinadorTODTOListCoordinador(IEnumerable<Usuario> coordinadores)
        {
            List<DTOCoordinador> lista = new List<DTOCoordinador>();
            lista = coordinadores.Select(a => new DTOCoordinador()
            {
              Nombre = a.Nombre,
              Id = a.Id,
            }).ToList();
            return lista;
        }
    }
}
