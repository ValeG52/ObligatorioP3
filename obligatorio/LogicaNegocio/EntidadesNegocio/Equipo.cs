using ExcepcionesPropias;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;


namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Equipo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Stock { get; set; }
        //public List<Prestamo> Prestamos { get; set; }

        public string NameTipoEquipo { get; set; }


        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Marca))
            {
                throw new DatosInvalidosException("La marca es obligatoria.");
            }
            if (string.IsNullOrEmpty(Modelo))
            {
                throw new DatosInvalidosException("El modelo es obligatorio.");
            }
            if (Stock == null || Stock < 0)
            {
                throw new DatosInvalidosException("El stock es obligatorio y debe ser mayor a cero.");
            }
        }

    }


}
