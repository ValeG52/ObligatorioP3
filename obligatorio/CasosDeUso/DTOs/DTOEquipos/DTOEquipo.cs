using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOEquipos
{
    public class DTOEquipo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Stock { get; set; }
        public Estado Estado { get; set; }
        public string TipoEquipo { get; set; }



    }
}
