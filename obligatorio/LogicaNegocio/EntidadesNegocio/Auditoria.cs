using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Auditoria
    {
        public int Id { get; set; }
        public string Accion {  get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Coordinador { get; set; }
        public Prestamo Prestamo   { get; set; }

        public void Validar() { }
    }
}
