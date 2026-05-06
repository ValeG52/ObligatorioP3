using LogicaNegocio.Enumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEnum
{
    public class CUListadoTipoMontura : ICUListadoTipoMontura

    {
        public string[] Ejecutar()
        {
            string[] lista = Enum.GetNames(typeof(TipoMontura));
            return lista;
        }
    }
}
