using ExcepcionesPropias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Enumerados;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            if(FindByNombreUsuario(item.NombreUsu) == null)
            {
                item.Validar();
                Contexto.Usuarios.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ConflictException("El nombre de usuario ya existe. Por favor, elija otro.");
            }
            
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

        public IEnumerable<Usuario> FindCoordinadores()
        {
            return Contexto.Usuarios.Where(u => u.Rol == Rol.Coordinador).ToList();

        }

        public IEnumerable<Usuario> FindSocios()
        {
            return Contexto.Usuarios.Where(u => u.Rol == Rol.Socio).ToList();
        }
    }
}
