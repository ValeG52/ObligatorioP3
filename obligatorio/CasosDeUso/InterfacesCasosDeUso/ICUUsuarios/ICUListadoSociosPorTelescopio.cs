using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUUsuarios
{
    public interface ICUListadoSociosPorTelescopio
    {
        public IEnumerable<DTOs.DTOUsuarios.DTOListadoUsuario> Ejecutar(int id);
    }
}
