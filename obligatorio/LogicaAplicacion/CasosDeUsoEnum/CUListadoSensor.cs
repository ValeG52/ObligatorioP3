using LogicaNegocio.Enumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Diagnostics;

namespace LogicaAplicacion.CasosDeUsoEnum
{
    public class CUListadoSensor : ICUListadoSensor

    {
        public List<string> Ejecutar()
        {
            string[] lista = Enum.GetNames(typeof(Sensor));
            List<string> sensores = lista.ToList();
            return sensores;
        }
    }
}
