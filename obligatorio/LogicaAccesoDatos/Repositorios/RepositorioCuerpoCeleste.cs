using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioCuerpoCeleste: IRepositorioCuerpoCeleste
    {

        public AppContexto Contexto { get; set; }
        public RepositorioCuerpoCeleste(AppContexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(CuerpoCeleste cc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CuerpoCeleste> FindAll()
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public CuerpoCeleste FindById(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(int id, CuerpoCeleste cc)
        {
            throw new NotImplementedException();
        }
    }
}
