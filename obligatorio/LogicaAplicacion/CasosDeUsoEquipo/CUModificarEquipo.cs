using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using ExcepcionesPropias;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoEquipo
{
    public class CUModificarEquipo : ICUModificarEquipo
    {
        public IRepositorioEquipo RepoEquipo {  get; set; }

        public CUModificarEquipo(IRepositorioEquipo repo) 
        {
            RepoEquipo = repo;
        }
        
        public void Ejecutar (int id, DTOEquipo dtoEquipo)
        {
            if (id > 0)
            {

                Equipo eBuscado = RepoEquipo.FindById(id);
                MapperEquipo.DTOEquipoToEquipo(dtoEquipo, eBuscado);
                RepoEquipo.Update(id, eBuscado);
            }else
            {
                throw new DatosInvalidosException("El id no es correcto");

            }
        }

    }

}
