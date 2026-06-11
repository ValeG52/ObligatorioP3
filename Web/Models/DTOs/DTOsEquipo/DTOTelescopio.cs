using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs.DTOEquipos
{
    public class DTOTelescopio : DTOEquipo
    {
        [Display(Name = "Apertura en mm")]
        public int Apertura { get; set; }
        [Display(Name = "Relacion focal ej. f/10, f/11, f/5")]

        public string RelFocal { get; set; }
        [Display(Name = "Distancia focal en mm")]
        public int DisFocal { get; set; }
        [Display(Name = "Peso en Kg")]
        [Range(0, double.MaxValue)]
        public int Peso { get; set; }
    }
}
