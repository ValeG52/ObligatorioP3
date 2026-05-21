using CasosDeUso.DTOs.DTOEquipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUEquipo
{
    public interface ICUListadoOcular
    {
        IEnumerable<DTOListadoOcular> Ejecutar();

    }
}
