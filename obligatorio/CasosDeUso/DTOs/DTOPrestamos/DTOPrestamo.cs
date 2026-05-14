using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOPrestamos
{
    public class DTOPrestamo
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public Usuario Usuario { get; set; }
        public List<Equipo> Equipos { get; set; }
        public Estado Estado { get; set; }
    }
}
