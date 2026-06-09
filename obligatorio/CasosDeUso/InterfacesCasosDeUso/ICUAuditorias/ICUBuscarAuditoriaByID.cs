using CasosDeUso.DTOs.DTOAuditoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUAuditorias
{
    public interface ICUBuscarAuditoriaByID
    {
        public DTOAuditoria Ejecutar(int idAuditoria);
    }
}
