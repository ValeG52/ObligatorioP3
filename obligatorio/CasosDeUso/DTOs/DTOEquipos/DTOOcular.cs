using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    internal class DTOOcular : DTOEquipo
    {
        public int Diametro {  get; set; }
        public int AnguloVision { get; set; }
    }
}
