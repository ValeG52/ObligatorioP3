using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Enumerados;


namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Equipo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Stock { get; set; }
        public Estado Estado {  get; set; }



        public abstract void Validar();

    }


}
