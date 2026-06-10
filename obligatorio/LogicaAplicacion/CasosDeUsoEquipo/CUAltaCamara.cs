using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InteracesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using CasosDeUso.DTOs.DTOEquipos;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUsoEquipo
{
    public class CUAltaCamara : ICUAltaCamara
    {
        public IRepositorioEquipo RepoEquipo { get; set; }

        public CUAltaCamara(IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }

        public int Ejecutar(DTOCamara dtoCamara)
        {
            Camara camara = MapperEquipo.DTOCamaraToCamara(dtoCamara);
            RepoEquipo.Add(camara);
            return camara.Id;
        }

    }
}
