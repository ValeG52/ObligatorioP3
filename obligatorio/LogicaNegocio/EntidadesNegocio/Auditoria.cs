using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Auditoria
    {
        public string Accion {  get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Coordinador { get; set; }

        public void Validar() { }
    }
}
