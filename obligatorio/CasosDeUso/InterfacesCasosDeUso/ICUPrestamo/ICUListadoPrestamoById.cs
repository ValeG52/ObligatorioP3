using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUPrestamo
{
    public interface ICUListadoPrestamoById
    {
        IEnumerable<DTOs.DTOPrestamos.DTOListadoPrestamo> Ejecutar(int id);

    }
}
