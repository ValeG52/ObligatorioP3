using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoUsuario
{
    public class CUListadoSociosPorTelescopio : ICUListadoSociosPorTelescopio
    {
        public IRepositorioPrestamo RepoPrestamo{ get; set; }
        public CUListadoSociosPorTelescopio(IRepositorioPrestamo repoUsuario)
        {
            RepoPrestamo = repoUsuario;
        }
        public IEnumerable<DTOListadoUsuario> Ejecutar (int idTelescopio)
        {
            IEnumerable<Usuario> uBuscados = RepoPrestamo.FindUsuariosByTelescopio(idTelescopio);
            return Mappers.MapperUsuario.ListUsuarosToDTOListadoUsuarios(uBuscados);
        }     
    }
}
