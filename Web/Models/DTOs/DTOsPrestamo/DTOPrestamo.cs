using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOUsuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
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
        public Estado Estado { get; set; }
        // propiedades para cargar los select
        public IEnumerable<DTOListadoUsuario> Usuarios { get; set; } = new List<DTOListadoUsuario>();

        public IEnumerable<DTOListadoCamara> Camaras { get; set; } = new List<DTOListadoCamara>();
        public IEnumerable<DTOListadoMontura> Monturas { get; set; } = new List<DTOListadoMontura>();
        public IEnumerable<DTOListadoTelescopio> Telescopios { get; set; } = new List<DTOListadoTelescopio>();
        public IEnumerable<DTOListadoOcular> Oculares { get; set; } = new List<DTOListadoOcular>();
        
    }
}
