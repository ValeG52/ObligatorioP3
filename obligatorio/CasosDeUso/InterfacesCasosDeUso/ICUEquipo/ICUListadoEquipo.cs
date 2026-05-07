using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUEquipo
{
    public interface ICUListadoEquipo
    {
        IEnumerable<DTOs.DTOEquipos.DTOEquipo> Ejecutar();

    }
}
