using CasosDeUso.DTOs;
using CasosDeUso.DTOs.DTOUsuarios;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUUsuarios
{
    public interface ICUAltaUsuario
    {
        void Ejecutar(DTOUsuario dtoUsuario);


    }

}
