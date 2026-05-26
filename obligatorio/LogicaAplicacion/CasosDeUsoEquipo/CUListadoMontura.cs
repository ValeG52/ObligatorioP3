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
    public class CUListadoMontura : ICUListadoMontura
    {
        
        
            public IRepositorioEquipo RepoEquipo { get; set; }
            public CUListadoMontura(IRepositorioEquipo repoEquipo)
            {
                RepoEquipo = repoEquipo;
            }
            public IEnumerable<DTOListadoMontura> Ejecutar()
            {
                List<Montura> montura = RepoEquipo.FindAllMontura().ToList();
                return MapperEquipo.ListadoMonturaToDTOListadoMontura(montura);
            }
        
    }
}
