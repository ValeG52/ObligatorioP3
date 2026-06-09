using ExcepcionesPropias;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Camara :Equipo
    {
        public Sensor Sensor { get; set; }
        public string Resolucion { get; set; }
        public int TamPixel { get; set; }



        public override void Validar()
        {
            if (Sensor == null)
            {
                throw new DatosInvalidosException("Elija un tipo de sensor.");

            }
            if (string.IsNullOrEmpty(Resolucion))
            {
                throw new DatosInvalidosException("La resolucion es requerida.");

            }
            if (TamPixel == null || TamPixel<=0)
            {
                throw new DatosInvalidosException("El tamanio del pixel es requerido y debe ser mayor o igual a cero.");

            }

        }

    }
}
