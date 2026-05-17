using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
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
        public List<int> EquiposIds { get; set; }
        public Estado Estado { get; set; }
    }
}
