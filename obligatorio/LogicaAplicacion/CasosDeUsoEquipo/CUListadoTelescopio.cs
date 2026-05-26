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
    public class CUListadoTelescopio : ICUListadoTelescopio
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUListadoTelescopio(IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }
        public IEnumerable<DTOListadoTelescopio> Ejecutar()
        {
            List<Telescopio> tele = RepoEquipo.FindAllTelescopio().ToList();
            return MapperEquipo.ListadoTelescopioToDTOListadoTelescopio(tele);
        }
    }
}
