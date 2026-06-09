using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOCamara : DTOEquipo
    {
        [DisplayName("Seleccione un sensor")]
        public Sensor Sensor { get; set; }
        public string Resolucion { get; set; }
        [DisplayName("Tamanio de mixel en micras")]
        public int TamPixel { get; set; }
        public string[] Sensores { get; set; }
        public int SensorId { get; set; }
        

    }
}
