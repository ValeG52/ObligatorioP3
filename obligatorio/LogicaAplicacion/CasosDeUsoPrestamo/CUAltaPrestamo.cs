using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InteracesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using CasosDeUso.DTOs.DTOPrestamos;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUAltaPrestamo : ICUAltaPrestamo
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public IRepositorioEquipo RepoEquipo    { get; set; }
        public IRepositorioUsuario RepoUsuario { get; set; }
        public CUAltaPrestamo (IRepositorioPrestamo repo, IRepositorioEquipo repoequipo, IRepositorioUsuario repoUsu)
        {
            RepoPrestamo = repo;
            RepoEquipo = repoequipo;
            RepoUsuario = repoUsu;
        }
        public void Ejecutar (DTOPrestamo dtoPrestamo)
        {
            List <Equipo> equipos = new List <Equipo> ();
            Usuario usuario = RepoUsuario.FindById(dtoPrestamo.UsuarioId);
            Equipo telescopio = RepoEquipo.FindById(dtoPrestamo.TelescopioId);
            Equipo montura = RepoEquipo.FindById(dtoPrestamo.MonturaId);
            equipos.Add(telescopio);
            equipos.Add(montura);
            if (dtoPrestamo.CamaraId != null)
            {
                Equipo camara = RepoEquipo.FindById((int)dtoPrestamo.CamaraId);
                equipos.Add(camara);
            }
            if (dtoPrestamo.OcularId != null)
            {
                Equipo ocular = RepoEquipo.FindById((int)dtoPrestamo.OcularId);
                equipos.Add(ocular);
            }
            // validar si algun parametro e null antes de agregarlo a la lista
            Prestamo prestamo = MapperPrestamo.DTOPrestamoToPrestamo(dtoPrestamo, equipos, usuario);
            RepoPrestamo.Add(prestamo);
        }
    }
}
