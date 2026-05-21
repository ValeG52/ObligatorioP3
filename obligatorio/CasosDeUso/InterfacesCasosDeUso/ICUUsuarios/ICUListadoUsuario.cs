using System;
using System.Collections.Generic;
using System.Text;
using CasosDeUso.DTOs.DTOUsuarios;

namespace CasosDeUso.InterfacesCasosDeUso.ICUUsuarios
{
    public interface ICUListadoUsuario
    {
        IEnumerable<DTOListadoUsuario> Ejecutar();
    }
}
