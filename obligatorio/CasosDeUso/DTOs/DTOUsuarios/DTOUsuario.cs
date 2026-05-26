using LogicaNegocio.Enumerados;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CasosDeUso.DTOs.DTOUsuarios
{
    public class DTOUsuario
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NombreUsu { get; set; }

        [Required]
        [MinLength(8)]
        public string Contrasenia { get; set; }

        [Required]
        public Rol? Rol { get; set; }
    }
}
