using CasosDeUso.DTOs.DTOPrestamos;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUPrestamo
{
    public interface ICUBuscarPrestamo
    {
        public DTOPrestamo Ejecutar(int id);
    }
}
