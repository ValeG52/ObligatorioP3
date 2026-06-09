using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InteracesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAuditoria : IRepository<Auditoria>
    {
        IEnumerable<Auditoria> FindAuditoriasById(int id);
    }
}
