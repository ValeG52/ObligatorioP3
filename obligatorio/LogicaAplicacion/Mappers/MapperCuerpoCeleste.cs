using CasosDeUso.DTOs.DTOCuerpoCeleste;
using CasosDeUso.DTOs.DTOPrestamos;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.Mappers
{
    public class MapperCuerpoCeleste
    {
        public static IEnumerable<DTOCuerpoCeleste> ListCCToDTOListCC(IEnumerable<CuerpoCeleste> listaCC)
        {
            IEnumerable<DTOCuerpoCeleste> ret = new List<DTOCuerpoCeleste>();
            ret = listaCC.Select(a => new DTOCuerpoCeleste()
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Tipo = a.Tipo,
                MagnitudAparente = a.MagnitudAparente,
            }).ToList();
            return ret;

        }
    }
}
