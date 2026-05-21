using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoUsuario
{
    public class CUListadoUsuario : ICUListadoUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public CUListadoUsuario (IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public IEnumerable<DTOListadoUsuario> Ejecutar()
        {
            List<Usuario> usuarios = RepoUsuario.FindAll().ToList();
            return MapperUsuario.ListUsuarosToDTOListadoUsuarios(usuarios);
        }
    }
}
