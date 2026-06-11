
using CasosDeUso.DTOs.DTOUsuarios;
using DTOs.DTOEquipos;
using DTOs.DTOUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs.DTOPrestamos
{
    public class DTOPrestamo
    {
        public int Id { get; set; }
        [DisplayName("Fecha del prestamo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType("Date")]
        public DateTime Inicio { get; set; }
        [DisplayName("Fecha de devuelto el equipo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType("Date")]
        public DateTime Fin { get; set; }
        
        [DisplayName("Usuario")]
        public int UsuarioId { get; set; }
        
        [DisplayName("Camaras")]
        public int? CamaraId { get; set; }
        [DisplayName("Monturas")]
        public int MonturaId { get; set; }
        [DisplayName("Telescopios")] 
        public int TelescopioId { get; set; }
        [DisplayName("Oculares")]
        public int? OcularId { get; set; }
        public int Estado { get; set; }
        // propiedades para cargar los select
        public IEnumerable<DTOSocio> Socios { get; set; } = new List<DTOSocio>();

        // propiedad para guardar un socio seleccionado (otro usuario de tipo socio)
        public DTOSocio Socio { get; set; }

        public IEnumerable<DTOListadoCamara> Camaras { get; set; } = new List<DTOListadoCamara>();
        public IEnumerable<DTOListadoMontura> Monturas { get; set; } = new List<DTOListadoMontura>();
        public IEnumerable<DTOListadoTelescopio> Telescopios { get; set; } = new List<DTOListadoTelescopio>();
        public IEnumerable<DTOListadoOcular> Oculares { get; set; } = new List<DTOListadoOcular>();
        
    }
}
