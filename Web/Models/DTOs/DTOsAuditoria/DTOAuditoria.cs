using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CasosDeUso.DTOs.DTOAuditoria
{
    public  class DTOAuditoria
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCoordinador { get; set; }
        public string NombreUsu {  get; set; }
        public int IDPrestamo { get; set; }
    }
}
