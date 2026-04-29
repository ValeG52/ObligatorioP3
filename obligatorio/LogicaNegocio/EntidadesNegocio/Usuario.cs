using LogicaNegocio.InteracesDominio;
using LogicaNegocio.Enumerados;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario : IValidable, IEquatable<Usuario>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NombreUsu { get; set; }
        public ContraseniaVO Contrasenia { get; set; }
        public Rol? Rol { get; set; } // o administrador, coordinador o socio

        public Usuario() { }

        public Usuario(string nombre, string direccion, string telefono, string email, string nombreUsu, string contrasenia)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            NombreUsu = nombreUsu;
            Contrasenia = new ContraseniaVO(contrasenia);
            

        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(Direccion))
                throw new Exception("La dirección es obligatoria.");

            if (string.IsNullOrWhiteSpace(Telefono))
                throw new Exception("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(Email))
                throw new Exception("El email es obligatorio.");

            if (string.IsNullOrWhiteSpace(NombreUsu))
                throw new Exception("El nombre de usuario es obligatorio.");      
        }

        public bool Equals(Usuario? other)
        {
            return NombreUsu == other?.NombreUsu;
        }

    }
}
