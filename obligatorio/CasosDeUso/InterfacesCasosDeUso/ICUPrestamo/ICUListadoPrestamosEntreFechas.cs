using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUPrestamo
{
    public interface ICUListadoPrestamosEntreFechas
    {
        public IEnumerable<DTOs.DTOPrestamos.DTOListadoPrestamo> Ejecutar(int idUsuario, int mes, int anio);
    }
}
