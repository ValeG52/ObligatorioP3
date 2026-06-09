using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.DTOs.DTOCuerpoCeleste
{
    public class DTOListadoCuerpoCeleste
    {
        public string Nombre { get; set; }
        public Tipo Tipo { get; set; }
        public int Contador { get; set; }
    }
}
