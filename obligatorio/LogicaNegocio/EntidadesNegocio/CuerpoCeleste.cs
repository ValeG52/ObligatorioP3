using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class CuerpoCeleste
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Tipo Tipo { get; set; }
        public decimal MagnitudAparente { get; set; }
        public int Contador { get; set; }

    }
}
