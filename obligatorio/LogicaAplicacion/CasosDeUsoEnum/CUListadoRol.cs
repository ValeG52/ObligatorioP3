using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEnum
{
    public class CUListadoRol : ICUListadoRol
    {
        public List<string> Ejecutar()
        {
            string[] lista = Enum.GetNames(typeof(Rol));
            List<string> roles = lista.ToList();
            return roles;
        }
    }
}
