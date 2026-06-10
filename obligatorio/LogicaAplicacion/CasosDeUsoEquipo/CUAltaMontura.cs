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
    public class CUAltaMontura : ICUAltaMontura
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUAltaMontura (IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }
        public int Ejecutar (DTOMontura dtoMontura)
        {
            Montura montura = MapperEquipo.DTOMonturaToMontura (dtoMontura);
            RepoEquipo.Add(montura);
            return montura.Id;

        }
    }
}
