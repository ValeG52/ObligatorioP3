using LogicaNegocio.Enumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEnum
{
    public class CUListadoTipoMontura : ICUListadoTipoMontura

    {
        public List<string> Ejecutar()
        {
            string[] lista = Enum.GetNames(typeof(TipoMontura));
            List<string> tipomontura = lista.ToList();

            return tipomontura;
        }
    }
}
