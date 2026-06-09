using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOOcular : DTOEquipo
    {
        [DisplayName("Diametro en pulgadas")]
        public int Diametro {  get; set; }
        [DisplayName("Angulo de vision en grados")]
        public int AnguloVision { get; set; }
        [DisplayName("Distancia focal en mm")]
        public int DisFolcalOcular {  get; set; }
    }
}
