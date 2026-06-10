
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
        public int Prestamo { get; set; } //idPrestamo
        [DisplayName("Seleccione un Cuerpo Celeste")]
        public int CuerpoCeleste { get; set; }
        public int Indicador { get; set; }
        public string Motivo { get; set; }
    }
}
