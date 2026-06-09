using CasosDeUso.DTOs.DTOAuditoria;
using CasosDeUso.DTOs.DTOCuerpoCeleste;
using LogicaAccesoDatos;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.Mappers
{
    public class MapperAuditoria
    {
        public static DTOAuditoria AuditoriaToDTOAuditoria(Auditoria a)
        {
            DTOAuditoria dto = new DTOAuditoria();
            dto.IdCoordinador = a.Coordinador.Id;
            dto.Id = a.Id;
            dto.IDPrestamo = a.Prestamo.Id;
            dto.NombreUsu = a.Coordinador.Nombre;
            dto.Fecha = a.Fecha;
            dto.Accion = a.Accion;
            return dto;
        }
        public static IEnumerable<DTOAuditoria> ListAuditoriaToDTOListAuditoria(IEnumerable<Auditoria> listaA)
        {
            IEnumerable<DTOAuditoria> ret = new List<DTOAuditoria>();
            ret = listaA.Select(a => new DTOAuditoria()
            {
                Id = a.Id,
                Accion = a.Accion,
                Fecha = a.Fecha,
                IdCoordinador = a.Coordinador.Id,
                NombreUsu = a.Coordinador.Nombre,
                IDPrestamo = a.Prestamo.Id,
            }).ToList();
            return ret;
        } 
    }

}
