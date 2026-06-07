using ExcepcionesPropias;
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

            if (telescopio == null)
                throw new DatosInvalidosException("Debe seleccionar un telescopio");

            if (montura == null)
                throw new DatosInvalidosException("Debe seleccionar una montura");

            if (camara == null && ocular == null)
                throw new DatosInvalidosException("Debe seleccionar una cámara o un ocular");

            if (telescopio.Stock <= 0)
                throw new DatosInvalidosException("El telescopio no tiene stock");

            if (montura.Stock <= 0)
                throw new DatosInvalidosException("La montura no tiene stock");

            if (camara != null && camara.Stock <= 0)
                throw new DatosInvalidosException("La cámara no tiene stock");

            if (ocular != null && ocular.Stock <= 0)
                throw new DatosInvalidosException("El ocular no tiene stock");

            if (montura.Carga < telescopio.Peso)
                throw new DatosInvalidosException("La montura no soporta el peso del telescopio");

            if (camara != null && montura.TipoMontura == TipoMontura.AltAzimutal)
                throw new DatosInvalidosException("La montura debe ser ecuatorial o híbrida para utilizar una cámara");
        }

        public void DescontarStock()
        {
            foreach(Equipo e in Equipos)
            {
                e.Stock--;
            }
        }
        public void DevolverStock()
        {
            foreach (Equipo e in Equipos)
            {
                e.Stock++;
            }
        }




    }

    
}
