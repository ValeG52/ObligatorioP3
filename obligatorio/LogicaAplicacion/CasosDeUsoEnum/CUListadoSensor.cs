using LogicaNegocio.Enumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEnum
{
    public class CUListadoSensor : ICUListadoSensor

    {
        public string[] Ejecutar()
        {
            string[] lista = Enum.GetNames(typeof(Sensor));
            return lista;
        }
    }
}
