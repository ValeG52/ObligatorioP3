using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Ocular: Equipo
    {
        public int Diametro { get; set; }
        public int AnguloVision {  get; set; }
        public int DisFolcalOcular { get; set; }


        public override void Validar()
        {
            if (Diametro == null || Diametro < 0)
            {
                throw new DatosInvalidosException("Diametro reequerido y debe ser mayor a cero");
            }
            if (AnguloVision == null || AnguloVision < 0)
            {
                throw new DatosInvalidosException("Angulo de vision reequerido y debe ser mayor a cero");
            }
            if (DisFolcalOcular == null || DisFolcalOcular < 0)
            {
                throw new DatosInvalidosException("Distancia focal requerida y debe ser mayor a cero");
            }

        }
    }
}
