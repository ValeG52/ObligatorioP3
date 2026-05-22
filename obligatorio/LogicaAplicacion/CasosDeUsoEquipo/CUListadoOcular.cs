using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEquipo
{
    public class CUListadoOcular :ICUListadoOcular
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUListadoOcular(IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }
        public IEnumerable<DTOListadoOcular> Ejecutar()
        {
            List<Ocular> ocular = RepoEquipo.FindAllOcular().ToList();
            return MapperEquipo.ListadoOcularToDTOListadoOcular(ocular);
        }
    }
}
