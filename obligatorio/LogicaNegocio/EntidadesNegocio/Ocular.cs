using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Ocular: Equipo
    {
        public int Dieametro { get; set; }
        public int AnguloVision {  get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
