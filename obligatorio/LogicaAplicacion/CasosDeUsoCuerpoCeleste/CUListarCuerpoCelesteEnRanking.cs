using CasosDeUso.DTOs.DTOCuerpoCeleste;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUCuerpoCeleste
{
    public class CUListarCuerpoCelesteEnRanking : ICUListarCuerpoCelesteEnRanking
    {
        public IRepositorioCuerpoCeleste RepoCC { get; set; }
        public CUListarCuerpoCelesteEnRanking(IRepositorioCuerpoCeleste repoCC)
        {
            RepoCC = repoCC;
        }
        public IEnumerable<DTORankingCuerpoCeleste> Ejecutar()
        {
            IEnumerable<CuerpoCeleste> ccBuscados = RepoCC.FindRanking();

            return MapperCuerpoCeleste.ListCCToDTOListCC(ccBuscados);
        }
    }
}
