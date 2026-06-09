using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOCuerpoCeleste
{
    public class DTOCuerpoCeleste
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Tipo Tipo { get; set; }
        public decimal MagnitudAparente { get; set; }
        public int Contador { get; set; }
    }
}
