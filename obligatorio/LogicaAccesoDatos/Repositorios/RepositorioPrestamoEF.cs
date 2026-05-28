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
            Contexto.Prestamos.Add(item);
            Contexto.SaveChanges();
        }
        public void Delete(int id)
        {
            
        }

        public IEnumerable<Prestamo> FindPrestamosUsuario(int id)
        {
            return Contexto.Prestamos.Where(p => p.Id == id && p.Estado == Estado.EnPrestamo).ToList();
        }
        public IEnumerable<Prestamo> FindAll() { return Contexto.Prestamos; }
        public Prestamo FindById(int id)
        {
            return Contexto.Prestamos.Where(p => p.Usuario.Id == id).SingleOrDefault();

        }
        public void Update(int id,Prestamo prestamo)
        {
            if (id > 0)
            {
                prestamo.Validar();               
                prestamo.Estado = Estado.Devuelto;               
                Contexto.SaveChanges();
            }
            else
            {
                throw new DatosInvalidosException("El id no es correcto");
            }

        }
    }
}
