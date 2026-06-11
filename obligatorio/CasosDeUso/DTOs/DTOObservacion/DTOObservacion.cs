using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace CasosDeUso.DTOs.DTOObservacion
{
    public class DTOObservacion
    {
        [DisplayName("Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType("Date")]
        public DateTime Fecha { get; set; }
        [DisplayName("Seleccione un Prestamo")]
        public Prestamo Prestamo { get; set; }
        [DisplayName("Seleccione un Cuerpo Celeste")]
        public CuerpoCeleste CuerpoCeleste { get; set; }
      
    }
}
