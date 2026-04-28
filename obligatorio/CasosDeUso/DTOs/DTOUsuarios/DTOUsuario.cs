using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOUsuarios
{
    public class DTOUsuario
    {
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NombreUsu { get; set; }
        public string Contrasenia { get; set; }

        public string Rol { get; set; } //administrador, coordinador o socio
    }
}
