using System;
using System.Collections.Generic;
using System.Text;
using CasosDeUso.DTOs.DTOEquipos;

namespace CasosDeUso.InterfacesCasosDeUso.ICUEquipo
{
    public interface ICUListadoCamara
    {
        IEnumerable<DTOListadoCamara> Ejecutar();

    }
}
