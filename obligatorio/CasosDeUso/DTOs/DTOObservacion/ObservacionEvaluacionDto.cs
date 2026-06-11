using LogicaNegocio.Enumerados;
using System;

namespace CasosDeUso.DTOs.DTOObservacion
{
    public class ObservacionEvaluacionDto
    {
        public DateTime Fecha { get; set; }
        public int PrestamoId { get; set; }
        public int CuerpoCelesteId { get; set; }
        public Indicador Indicador { get; set; }
        public string Motivo { get; set; }
    }
}
