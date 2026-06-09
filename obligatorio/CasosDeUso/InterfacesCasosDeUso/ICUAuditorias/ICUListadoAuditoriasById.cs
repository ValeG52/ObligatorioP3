using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasosDeUso.InterfacesCasosDeUso.ICUAuditorias
{
    public interface ICUListadoAuditoriasById
    {
        public IEnumerable<DTOs.DTOAuditoria.DTOAuditoria> Ejecutar(int id);
    }
}
