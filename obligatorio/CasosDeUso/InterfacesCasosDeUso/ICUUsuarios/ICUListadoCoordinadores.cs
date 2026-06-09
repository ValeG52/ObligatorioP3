using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUUsuarios
{
    public interface ICUListadoCoordinadores
    {
        public IEnumerable<DTOs.DTOUsuarios.DTOCoordinador> Ejecutar();
    }
}
