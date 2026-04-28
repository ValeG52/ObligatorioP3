using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LogicaNegocio.ValueObject;
using CasosDeUso.DTOs.DTOUsuarios;

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
    }
}
