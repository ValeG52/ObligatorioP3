using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InteracesRepositorios
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(int id, T item);
        void Delete(int id);
        IEnumerable<T> FindAll();
        T FindById(int id);
    }
}
