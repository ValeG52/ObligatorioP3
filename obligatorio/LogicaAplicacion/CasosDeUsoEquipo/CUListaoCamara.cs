using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEquipo
{
    public class CUListaoCamara :ICUListadoCamara
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUListaoCamara (IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }
        public IEnumerable<DTOListadoCamara> Ejecutar()
        {
            List <Camara> camaras = RepoEquipo.MapperEquipo.FindAll().ToList();
            retun MapperEquipo.ListadoCamaraToDTOListadoCamara(camaras);
        }
    }
}
