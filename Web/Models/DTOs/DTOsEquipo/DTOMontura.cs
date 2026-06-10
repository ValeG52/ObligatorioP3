using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DTOs.DTOEquipos
{
    public class DTOMontura : DTOEquipo
    {
        public int TipoMontura { get; set; }
        public int Carga { get; set; }
        public bool Computarizado { get; set; }
        public string[] TipoMonturas { get; set; }
        public int TipoMonturaId { get; set; }
    }
}
