using CasosDeUso.DTOs.DTOEquipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUEquipo
{
    public interface ICUAltaTelescopio
    {
        int Ejecutar(DTOTelescopio  dtoTelescopio);

    }
}
