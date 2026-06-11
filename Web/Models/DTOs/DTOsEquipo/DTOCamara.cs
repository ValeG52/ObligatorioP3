using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs.DTOEquipos
{
    public class DTOCamara : DTOEquipo
    {
        
        public int Sensor { get; set; }
        public string Resolucion { get; set; }
        [Display(Name = "Tamanio de mixel en micras")]
        public int TamPixel { get; set; }
        [Display(Name = "Seleccione un sensor")]
        public List<string>? Sensores { get; set; }
        public int SensorId { get; set; }


    }
}
