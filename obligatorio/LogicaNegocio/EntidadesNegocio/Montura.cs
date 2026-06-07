using ExcepcionesPropias;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Montura: Equipo
    {
        public TipoMontura TipoMontura { get; set; }
        public int Carga { get; set; }
        public bool Computarizado   { get; set; }


        public override void Validar()
        {
           if (TipoMontura == null)
            {
                throw new DatosInvalidosException("Seleccione un tipo de montura");

            }
            if (Carga == null || Carga<0)
            {
                throw new DatosInvalidosException("La carga es requerida y debe ser mayor a cero");

            }

        }
    }
}
