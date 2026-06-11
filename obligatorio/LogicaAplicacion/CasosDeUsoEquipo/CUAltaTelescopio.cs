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
    public class CUAltaTelescopio: ICUAltaTelescopio
    {
        public IRepositorioEquipo RepoEquipo { get; set; }

        public CUAltaTelescopio(IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }

        public int Ejecutar(DTOTelescopio dtoTelescopio)
        {
            Telescopio telescopio = MapperEquipo.DTOTelescopioToTelescopio(dtoTelescopio);
            RepoEquipo.Add(telescopio);
            return telescopio.Id;
        }
    }


}
