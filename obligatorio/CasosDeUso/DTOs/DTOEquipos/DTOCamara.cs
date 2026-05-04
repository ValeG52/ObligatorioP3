using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOCamara : DTOEquipo
    {
        public Sensor Sensor { get; set; }
        public string Resolucion { get; set; }
        public int TamanioPixel { get; set; }

    }
}
