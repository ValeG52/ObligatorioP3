using CasosDeUso.DTOs.DTOAuditoria;
using CasosDeUso.InterfacesCasosDeUso.ICUAuditorias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoAuditoria
{
    public  class CUBuscarAuditoriaByID : ICUBuscarAuditoriaByID
    {
        public IRepositorioAuditoria RepoAuditoria { get; set; }
        public CUBuscarAuditoriaByID(IRepositorioAuditoria repoAuditoria)
        {
            RepoAuditoria = repoAuditoria;
        }

        public DTOAuditoria Ejecutar (int idAuditoria)
        {
            Auditoria aBuscada = RepoAuditoria.FindById(idAuditoria);
            return Mappers.MapperAuditoria.AuditoriaToDTOAuditoria(aBuscada);
        }
    }
}
