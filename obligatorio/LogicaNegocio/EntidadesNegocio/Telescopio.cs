using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Telescopio : Equipo
    {
        public int Apertura {  get; set; }
        public string RelFocal { get; set; }
        public int DisFocal { get; set; }
        public int Peso { get; set; }

        public override void Validar()
        {
            if (Apertura == null || Apertura < 0)
            {
                throw new DatosInvalidosException("La apertura es requerida y debe ser mayor o igual a cero");

            }
            if ( string.IsNullOrEmpty(RelFocal) )
            {
                throw new DatosInvalidosException("La relacion focal es requerida ");

            }
            if (DisFocal == null || DisFocal < 0)
            {
                throw new DatosInvalidosException("La distancia focal es requerida y debe ser mayor o igual a cero");

            }
            if (Peso == null || Peso < 0)
            {
                throw new DatosInvalidosException("El peso es requerido y debe ser mayor o igual a cero");

            }
        }
    }
}
