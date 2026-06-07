using ExcepcionesPropias;
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
        public string Motivo { get; set; }


        public void Validar()
        {
            if(Prestamo == null)
            {
                throw new DatosInvalidosException("Elija un prestamo");
            }
            if (CuerpoCeleste == null)
            {
                throw new DatosInvalidosException("Elija un cuerpo celeste");
            }
            if (string.IsNullOrWhiteSpace(Motivo))
            {
                throw new DatosInvalidosException("Debe existir un motivo");
            }

        }
         
    }
}
