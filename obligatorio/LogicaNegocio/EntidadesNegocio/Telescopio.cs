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
            throw new NotImplementedException();
        }
    }
}
