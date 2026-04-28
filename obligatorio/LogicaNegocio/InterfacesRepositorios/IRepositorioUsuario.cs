using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InteracesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepository<Usuario>
    {
        Usuario Login(string email, string contrasenia);
        Usuario FindByNombreUsuario(string nombreUsuario);
    }
}
