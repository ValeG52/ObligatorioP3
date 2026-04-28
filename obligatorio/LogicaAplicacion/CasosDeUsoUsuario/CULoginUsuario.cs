using System;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using CasosDeUso.InterfacesCasosDeUso;
using CasosDeUso.DTOs.DTOUsuarios;

namespace CasosDeUso.ManejoUsuarios
{
    public class CULoginUsuario : ICULoginUsuario
    {
        private IRepositorioUsuario _repo;

        public CULoginUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public DTOUsuario Ejecutar(string email, string password)
        {     
            Usuario usuarioEncontrado = _repo.Login(email, password);

            if (usuarioEncontrado == null)
            {
                throw new Exception("Credenciales inválidas.");
            }

            return new DTOUsuario
            {
                Email = usuarioEncontrado.Email,
                Rol = usuarioEncontrado.Rol
            };
        }
    }
}