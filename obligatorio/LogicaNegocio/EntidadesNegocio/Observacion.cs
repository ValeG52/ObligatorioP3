using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Observacion
    {
        public DateTime Fecha {  get; set; }
        public Prestamo Prestamo { get; set; }
        public CuerpoCeleste CuerpoCeleste { get; set; }
        public Indicador Indicador { get; set; }

        public void Validar()
        {

        }
         
    }
}
