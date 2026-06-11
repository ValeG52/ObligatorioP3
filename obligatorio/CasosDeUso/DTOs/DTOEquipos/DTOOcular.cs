using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOOcular : DTOEquipo
    {
        [Display(Name = "Diametro en pulgadas")]
        public int Diametro {  get; set; }
        [Display(Name = "Angulo de vision en grados")]
        public int AnguloVision { get; set; }
        [Display(Name = "Distancia focal en mm")]
        public int DisFolcalOcular {  get; set; }
    }
}
