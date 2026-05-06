using CasosDeUso.DTOs.DTOEquipos;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUEquipo
{
    public interface ICUAltaCamara
    {
        void Ejecutar(DTOCamara dtoCamara);
    }
}
