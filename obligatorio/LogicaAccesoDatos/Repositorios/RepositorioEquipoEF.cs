using ExcepcionesPropias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEquipoEF : IRepositorioEquipo
    {
        public AppContexto Contexto { get ; set; }

        public RepositorioEquipoEF(AppContexto context)
        {
            Contexto = context;
        }

        public void Add(Equipo item)
        {
            item.Validar();
            Contexto.Equipos.Add(item);
            Contexto.SaveChanges();
        }
        public void Delete(int id) 
        {
            if (id > 0)
            {
                Equipo eBuscado = FindById(id);
                if (eBuscado != null)
                {
                    Contexto.Equipos.Remove(eBuscado);
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
        public IEnumerable<Equipo> FindAll() { return Contexto.Equipos; }
        public Equipo FindById (int id) 
        {
            return Contexto.Equipos.Where(p => p.Id == id).SingleOrDefault();

        }
        public void Update(int id, Equipo equipo) 
        {
            if (id > 0)
            {
                equipo.Validar();
                Equipo eBuscado = FindById(id);
                eBuscado.Marca = equipo.Marca;
                eBuscado.Modelo = equipo.Modelo;
                eBuscado.Stock = equipo.Stock;
                eBuscado.NameTipoEquipo = equipo.NameTipoEquipo;
                Contexto.SaveChanges();
            }
            else
            {
                throw new DatosInvalidosException("El id no es correcto");
            }
        }

    }
}
