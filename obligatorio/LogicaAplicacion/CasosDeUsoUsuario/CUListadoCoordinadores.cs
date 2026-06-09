using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoUsuario
{
    public class CUListadoCoordinadores : ICUListadoCoordinadores
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public CUListadoCoordinadores (IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public IEnumerable<DTOCoordinador> Ejecutar()
        {
            IEnumerable<Usuario> coordinadores = RepoUsuario.FindCoordinadores();
            return Mappers.MapperUsuario.ListCoordinadorTODTOListCoordinador(coordinadores);
        }
    }
}
