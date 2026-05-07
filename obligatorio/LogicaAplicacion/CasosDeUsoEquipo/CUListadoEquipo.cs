using System;
using System.Collections.Generic;
using System.Text;
using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUsoEquipo
{
    public class CUListadoEquipo : ICUListadoEquipo
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUListadoEquipo(IRepositorioEquipo repo)
        {
            RepoEquipo = repo;
        }

        public IEnumerable<DTOEquipo> Ejecutar()
        {
            List<Equipo> equipos = RepoEquipo.FindAll().ToList();
            return MapperEquipo.ListEquipoToListDTOEquipo(equipos);
        }

    }
}
