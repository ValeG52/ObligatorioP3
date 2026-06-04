using CasosDeUso.DTOs.DTOCuerpoCeleste;
using CasosDeUso.InterfacesCasosDeUso;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoCuerpoCeleste
{
    public class CUListarCuerpoCeleste :ICUListarCuerpoCeleste
    {
        public IRepositorioCuerpoCeleste RepoCC { get; set; }
        public CUListarCuerpoCeleste (IRepositorioCuerpoCeleste repoCC)
        {
            RepoCC = repoCC;
        }
        public IEnumerable<DTOCuerpoCeleste> Ejecutar()
        {
            IEnumerable<CuerpoCeleste> ccBuscados = RepoCC.FindAll().ToList();
            return MapperCuerpoCeleste.ListCCToDTOListCC(ccBuscados);
        }
    }
}
