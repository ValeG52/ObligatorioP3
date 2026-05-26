using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime Inicio {  get; set; }
        public DateTime Fin {  get; set; }
        public Usuario Usuario { get; set; }
        public List<Equipo> Equipos { get; set; }
        public Estado Estado { get; set; }

        public void Validar()
        {

        }

    }
}
