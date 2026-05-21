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
    public class CUListadoCamara :ICUListadoCamara
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUListadoCamara (IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }
        public IEnumerable<DTOListadoCamara> Ejecutar()
        {
            List <Camara> camaras = RepoEquipo.FindAllCamaras().ToList();
            return MapperEquipo.ListadoCamaraToDTOListadoCamara(camaras);
        }
    }
}
