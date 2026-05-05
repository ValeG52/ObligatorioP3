using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEnum
{
    public class CUListadoEstado : ICUListadoEstado
    {
        public string[] Ejecutar()
        {
            string[] lista = Enum.GetNames(typeof(Estado));
            return lista;
        }
    }
}
