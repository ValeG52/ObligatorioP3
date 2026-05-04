using CasosDeUso.DTOs.DTOEquipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUEquipo
{
    internal interface ICUAltaMontura
    {
        void Ejecutar(DTOMontura dtoMontura);

    }
}
