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
            Telescopio telescopio = Equipos.OfType<Telescopio>().FirstOrDefault();
            Montura montura = Equipos.OfType<Montura>().FirstOrDefault();
            Camara camara = Equipos.OfType<Camara>().FirstOrDefault();
            Ocular ocular = Equipos.OfType<Ocular>().FirstOrDefault();
            if (telescopio == null) { }
            
            if (montura == null) { }
            if (camara == null && ocular == null) { }
            if (montura.TipoMontura == TipoMontura.AltAzimutal && camara != null) { }
            if (telescopio.Stock <= 0) { }
            if (montura.Stock <= 0) { }
            if (montura.Carga < telescopio.Peso) { }
            if (ocular.Stock <= 0) { }
            if (camara.Stock <= 0) { }
        }

    }
}
