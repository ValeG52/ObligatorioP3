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
    public class CUAltaOcular : ICUAltaOcular
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUAltaOcular (IRepositorioEquipo repo)
        {
            RepoEquipo = repo;
        }

        public void Ejecutar (DTOOcular dtoOcular)
        {
            Ocular ocular = MapperEquipo.DTOOcularToOcular (dtoOcular);
            RepoEquipo.Add(ocular);
        }
    }
}
