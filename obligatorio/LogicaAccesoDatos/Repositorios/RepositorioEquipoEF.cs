using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void Delete(int id) { }
        public IEnumerable<Equipo> FindAll() { return null; }
        public Equipo FindById (int id) { return null; }
        public void Update(int id, Equipo equipo) { }

    }
}
