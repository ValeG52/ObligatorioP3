using ExcepcionesPropias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioPrestamoEF: IRepositorioPrestamo
    {
        public AppContext Contexto { get; set; }
        public RepositorioPrestamoEF (AppContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Equipo item)
        {
            item.Validar();
            Contexto.Prestamos.Add(item);
            Contexto.SaveChanges();
        }
        public void Delete(int id)
        {
            if (id > 0)
            {
                Equipo eBuscado = FindById(id);
                if (eBuscado != null)
                {
                    Contexto.Prestamos.Remove(eBuscado);
                    Contexto.SaveChanges();
                }
                else
                {
                    throw new DatosInvalidosException("No se encontro un pais con ese id");

                }
            }
            else
            {
                throw new DatosInvalidosException("El id no es correcto");
            }
        }
        public IEnumerable<Equipo> FindAll() { return Contexto.Prestamos; }
        public Equipo FindById(int id)
        {
            return Contexto.Prestamos.Where(p => p.Id == id).SingleOrDefault();

        }
        public void Update(int id, Equipo equipo)
        {
            
        }
    }
}
