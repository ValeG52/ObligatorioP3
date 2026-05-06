using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Enumerados;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Montura: Equipo
    {
        public TipoMontura TipoMontura { get; set; }
        public int Carga { get; set; }
        public bool Computarizado   { get; set; }


        public override void Validar()
        {
           
        }
    }
}
