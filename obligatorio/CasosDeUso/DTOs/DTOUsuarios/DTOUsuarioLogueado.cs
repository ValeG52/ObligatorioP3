using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOUsuarios
{
    public class DTOUsuarioLogueado
    {
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
