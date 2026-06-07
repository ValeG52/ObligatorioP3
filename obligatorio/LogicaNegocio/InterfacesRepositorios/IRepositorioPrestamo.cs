using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InteracesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPrestamo: IRepository<Prestamo>
    {
        IEnumerable<Prestamo> FindPrestamosUsuario(int id);
        IEnumerable<Prestamo> FindPrestamosVigentesUsuario(int idUsuario, DateTime fechaActual);
        IEnumerable<Prestamo> FindPrestamosMesAnioUsuario(int id, int mes, int anio);
        IEnumerable<Usuario> FindUsuariosByTelescopio(int idTelescopio);

    }
}
