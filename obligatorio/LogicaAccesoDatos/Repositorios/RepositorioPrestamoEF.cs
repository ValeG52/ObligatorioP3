using ExcepcionesPropias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Enumerados;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioPrestamoEF: IRepositorioPrestamo
    {
        public AppContexto Contexto { get; set; }
        public RepositorioPrestamoEF (AppContexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Prestamo item)
        {
            item.Validar();
            item.DescontarStock();
            Contexto.Prestamos.Add(item);
            Contexto.SaveChanges();
        }
        public void Delete(int id)
        {
            
        }

        public IEnumerable<Prestamo> FindPrestamosVigentesUsuario(int idUsu, DateTime fecha)
        {
            // Incluir todos los préstamos no devueltos (Estado.EnPrestamo) del usuario,
            // incluso si la fecha de fin ya pasó (se consideran atrasados pero siguen sin devolver).
            return Contexto.Prestamos.Where(p => p.Usuario.Id == idUsu && p.Estado == Estado.EnPrestamo).ToList();
        }

        public IEnumerable<Prestamo> FindPrestamosUsuario(int idPrestamo)
        {
            return Contexto.Prestamos.Where(p => p.Id == idPrestamo && p.Estado == Estado.EnPrestamo).ToList();
        }
        public IEnumerable<Prestamo> FindAll() { return Contexto.Prestamos; }
        public Prestamo FindById(int id)
        {
            return Contexto.Prestamos.Where(p => p.Id == id).SingleOrDefault();

        }
        public void Update(int id,Prestamo prestamo)
        {
            if (id > 0)
            {
                prestamo.Validar();               
                               
                Contexto.SaveChanges();
            }
            else
            {
                throw new DatosInvalidosException("El id no es correcto");
            }

        }
        public IEnumerable<Prestamo> FindPrestamosMesAnioUsuario(int idUsuario, int mes, int anio)
        {
            // Filtrar por rango de fechas para evitar problemas de traducción de Member access (Month/Year) a SQL
            var inicioMes = new DateTime(anio, mes, 1);
            var inicioMesSiguiente = inicioMes.AddMonths(1);
            return Contexto.Prestamos
                .Where(p => p.Usuario.Id == idUsuario && p.Inicio >= inicioMes && p.Inicio < inicioMesSiguiente)
                .ToList();
        }

        public IEnumerable<Usuario> FindUsuariosByTelescopio(int idTelescopio)
        {
            IEnumerable<Prestamo> prestamos = Contexto.Prestamos.Where(p => p.Equipos.Any(e => e.Id == idTelescopio));
            List<Usuario> usuarios = new List<Usuario>();
            foreach (Prestamo p  in prestamos)
            {
               usuarios.Add(p.Usuario);
            }
            return usuarios.GroupBy(u => u.Id).Select(g => g.First()).OrderByDescending(u => u.Nombre).ToList();
        }
    }
}
