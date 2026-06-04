using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso
{
    public interface ICUListarCuerpoCeleste
    {
        public IEnumerable<DTOs.DTOCuerpoCeleste.DTOCuerpoCeleste> Ejecutar();
    }
}
