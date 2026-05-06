using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOTelescopio : DTOEquipo
    {
        public int Apertura { get; set; }
        public string RelFocal  { get; set; }
        public int DisFocal { get; set; }
        public int Peso {  get; set; }
    }
}
