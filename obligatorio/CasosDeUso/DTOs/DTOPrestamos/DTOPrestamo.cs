using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
using CasosDeUso.DTOs.DTOEquipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOPrestamos
{
    public class DTOPrestamo
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<DTOListadoCamara> Camaras { get; set; } = new List<DTOListadoCamara>();
        public IEnumerable<DTOListadoMontura> Monturas { get; set; } = new List<DTOListadoMontura>();
        public IEnumerable<DTOListadoTelescopio> Telescopios { get; set; } = new List<DTOListadoTelescopio>();
        public IEnumerable<DTOListadoOcular> Oculares { get; set; } = new List<DTOListadoOcular>();
        public Estado Estado { get; set; }
    }
}
