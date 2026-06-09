using CasosDeUso.DTOs.DTOAuditoria;
using CasosDeUso.InterfacesCasosDeUso.ICUAuditorias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoAuditoria
{
    public class CUListadoAuditoriasById : ICUListadoAuditoriasById
    {
        public IRepositorioAuditoria RepoAuditoria { get; set; }
        public CUListadoAuditoriasById(IRepositorioAuditoria repoAuditoria)
        {
            RepoAuditoria = repoAuditoria;
        }
        
        public IEnumerable<DTOAuditoria> Ejecutar (int id)
        {
            IEnumerable<Auditoria> listaAudi = RepoAuditoria.FindAuditoriasById(id);
            return Mappers.MapperAuditoria.ListAuditoriaToDTOListAuditoria(listaAudi);
        }
    }
}
