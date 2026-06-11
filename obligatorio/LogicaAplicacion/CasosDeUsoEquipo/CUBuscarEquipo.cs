using System;
using System.Collections.Generic;
using System.Text;
using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using ExcepcionesPropias;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;



namespace LogicaAplicacion.CasosDeUsoEquipo
{
    public class CUBuscarEquipo : ICUBuscarEquipo
    {
        public IRepositorioEquipo RepoEquipo    { get; set; }   
        public CUBuscarEquipo (IRepositorioEquipo repo)
        {
            RepoEquipo = repo;
        }
    
    public DTOEquipo Ejecutar(int id)
        {
            if (id <= 0)
            {
                throw new DatosInvalidosException("El id del equipo debe ser un número positivo.");
            }
            Equipo equipo = RepoEquipo .FindById(id);
            if (equipo == null)
            {
                throw new NotFoundException($"No se encontró ningún equipo con el id {id}.");
            }
            return MapperEquipo.EquipoToListDTOEquipo(equipo);
        }
    }
}
