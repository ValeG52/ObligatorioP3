using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LogicaAplicacion.CasosDeUsoUsuario
{
    public class CUListadoSocios : ICUListadoSocios
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public CUListadoSocios (IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public IEnumerable<DTOSocio> Ejecutar()
        {
            IEnumerable<Usuario> socios = RepoUsuario.FindSocios();
            return Mappers.MapperUsuario.ListCoordinadorTODTOListCoordinador(socios).Select(a => new DTOSocio { Id = a.Id, Nombre = a.Nombre });
        }
    }
}
