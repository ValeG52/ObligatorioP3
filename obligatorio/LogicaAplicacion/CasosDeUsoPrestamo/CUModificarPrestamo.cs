using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using ExcepcionesPropias;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoPrestamo
{
    public class CUModificarPrestamo : ICUModificarPrestamo
    {
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public IRepositorioAuditoria RepoAuditoria { get; set; }
        public IRepositorioUsuario RepoUsuario {  get; set; }
        public CUModificarPrestamo (IRepositorioPrestamo repoPrestamo,IRepositorioAuditoria repoAuditoria, IRepositorioUsuario repoUsu)
        {
            RepoPrestamo = repoPrestamo;
            RepoUsuario = repoUsu;
            RepoAuditoria = repoAuditoria;
        }
        public void Ejecutar(int id, int idCoordinador)
        {
            if (id > 0)
            {

                Prestamo pBuscado = RepoPrestamo.FindById(id);
                pBuscado.Estado = Estado.Devuelto;
                pBuscado.DevolverStock();
                RepoPrestamo.Update(id, pBuscado);
                Auditoria aCreada = new Auditoria();
                aCreada.Accion = "Devolucion";
                aCreada.Fecha = DateTime.Now;
                Usuario coordinador = RepoUsuario.FindById(idCoordinador);
                aCreada.Coordinador = coordinador;
                aCreada.Prestamo = pBuscado;
                RepoAuditoria.Add(aCreada);
            }
            else
            {
                throw new DatosInvalidosException("El id no es correcto");

            }
        }
    }
}
