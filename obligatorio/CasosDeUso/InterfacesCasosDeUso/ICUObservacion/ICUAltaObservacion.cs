using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUObservacion
{
    public interface ICUAltaObservacion
    {
        public void Ejecutar(int idPrestamo, int idCuerpoCeleste, DateTime fechaObservacion);
    }
}
