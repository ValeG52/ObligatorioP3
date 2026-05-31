using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs.DTOEquipos
{
    public class DTOTelescopio : DTOEquipo
    {
        public int Apertura { get; set; }
        public string RelFocal  { get; set; }
        public int DisFocal { get; set; }
        [Range(0, double.MaxValue)]
        public int Peso {  get; set; }
    }
}
