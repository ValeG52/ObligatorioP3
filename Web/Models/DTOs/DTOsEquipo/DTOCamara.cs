using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOEquipos
{
    public class DTOCamara : DTOEquipo
    {
        public Sensor Sensor { get; set; }
        public string Resolucion { get; set; }
        public int TamPixel { get; set; }
        public string[] Sensores { get; set; }
        public int SensorId { get; set; }
        

    }
}
