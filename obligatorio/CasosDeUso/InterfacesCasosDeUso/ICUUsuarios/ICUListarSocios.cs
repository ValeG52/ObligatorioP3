using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUUsuarios
{
    public interface ICUListadoSocios
    {
        public IEnumerable<DTOs.DTOUsuarios.DTOSocio> Ejecutar();
    }
}
