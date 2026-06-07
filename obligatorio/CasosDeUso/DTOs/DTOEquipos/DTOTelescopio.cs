using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOTelescopio : DTOEquipo
    {
        [DisplayName("Apertura en mm")]
        public int Apertura { get; set; }
        [DisplayName("Relacion focal ej. f/10, f/11, f/5")]

        public string RelFocal  { get; set; }
        [DisplayName("Distancia focal en mm")]
        public int DisFocal { get; set; }
        [DisplayName("Peso en Kg")]
        [Range(0, double.MaxValue)]
        public int Peso {  get; set; }
    }
}
