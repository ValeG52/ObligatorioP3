using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOMontura : DTOEquipo
    {
        [Display(Name = "Seleccione un tipo de montura")]
        public TipoMontura TipoMontura { get; set; }
        [Display(Name = "Carga en Kg")]
        public int Carga { get; set; }
        public bool Computarizado { get; set; }
        public List<string>? TipoMonturas { get; set; }
        public int TipoMonturaId { get; set; }
    }
}
