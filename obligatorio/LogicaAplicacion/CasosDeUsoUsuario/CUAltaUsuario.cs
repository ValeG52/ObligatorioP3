using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;
using CasosDeUso.DTOs.DTOUsuarios;
using LogicaAplicacion.Mappers;

namespace LogicaDeAplicacion.CasosDeUsoUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; } 

        public CUAltaUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }


        public void Ejecutar(DTOUsuario dtoUsuario)
        {
            Usuario usuario = MapperUsuario.UsuarioDTOUsuarioToUsuario(dtoUsuario);
            usuario.Validar();

            if(RepoUsuario.FindByNombreUsuario(dtoUsuario.NombreUsu)!=null)
            {
                throw new Exception("El nombre de usuario ya existe.");
            }

            RepoUsuario.Add(usuario);
        }

        public void AltaUsuario(Usuario nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
