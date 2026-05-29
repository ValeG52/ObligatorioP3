using ExcepcionesPropias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;


using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria: IRepositorioAuditoria
    {
        public AppContexto Contexto { get; set; }
        public RepositorioAuditoria(AppContexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Auditoria item)
        {
            item.Validar();
            Contexto.Auditorias.Add(item);
            Contexto.SaveChanges();
        }
    }
}
