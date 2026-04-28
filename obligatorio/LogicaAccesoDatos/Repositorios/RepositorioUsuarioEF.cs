using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        public AppContexto Contexto { get; set; }
        
        public RepositorioUsuarioEF(AppContexto contexto)
        {    
            Contexto = contexto;
        }


        public void Add(Usuario item)
        {
            item.Validar();
            Contexto.Usuarios.Add(item);
            Contexto.SaveChanges();
        }
        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario Login(string email, string contrasenia)
        {
            return Contexto.Usuarios.Where(u => u.Email == email && u.Contrasenia.Contrasenia == contrasenia).FirstOrDefault();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario FindByNombreUsuario(string nombreUsuario)
        {
            return Contexto.Usuarios.FirstOrDefault(u => u.NombreUsu == nombreUsuario);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
      
        public void Update(int id, Usuario item)
        {
            throw new NotImplementedException();
        }
    }
}
