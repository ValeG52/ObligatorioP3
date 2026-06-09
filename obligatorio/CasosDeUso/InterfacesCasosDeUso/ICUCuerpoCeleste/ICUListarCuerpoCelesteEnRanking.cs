using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUCuerpoCeleste
{
    public interface ICUListarCuerpoCelesteEnRanking
    {
        public IEnumerable<DTOs.DTOCuerpoCeleste.DTOListadoCuerpoCeleste> Ejecutar();
    }
}
