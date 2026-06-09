using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioObservacionEF : IRepositorioObservacion
    {
        public AppContexto Contexto { get; set; }
        public RepositorioObservacionEF(AppContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Observacion item)
        {
            item.Validar();
            Contexto.Observaciones.Add(item);
            Contexto.SaveChanges();
        }

        public IEnumerable<Observacion> FindAll()
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Observacion FindById(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(int id, Observacion item)
        {
            throw new NotImplementedException();
        }
    }
}
