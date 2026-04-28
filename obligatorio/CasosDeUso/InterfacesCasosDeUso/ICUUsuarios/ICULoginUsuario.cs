using CasosDeUso.DTOs.DTOUsuarios;

namespace CasosDeUso.InterfacesCasosDeUso
{
    public interface ICULoginUsuario
    {
      
        DTOUsuario Ejecutar(string email, string contrasenia);
    }
}