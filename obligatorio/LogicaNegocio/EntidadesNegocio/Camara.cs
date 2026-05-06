using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Enumerados;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Camara :Equipo
    {
        public Sensor Sensor { get; set; }
        public string Resolucion { get; set; }
        public int TamPixel { get; set; }



        public override void Validar()
        {
            
        }

    }
}
