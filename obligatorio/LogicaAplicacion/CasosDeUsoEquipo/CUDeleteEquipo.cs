using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEquipo
{
    public class CUDeleteEquipo : ICUDeleteEquipo
    {
        public IRepositorioEquipo RepoEquipo { get; set; }
        public CUDeleteEquipo(IRepositorioEquipo repo) 
        {
            RepoEquipo = repo;
        }
        public void Ejecutar(int id)
        {
            //tendria que validar el id 
            if (id > 0 )
            {
                RepoEquipo.Delete(id);
            }
            else
            {
                throw new DatosInvalidosException("El id no es correcto");
            }
        }
    }
}
