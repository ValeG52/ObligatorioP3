using System;

namespace CasosDeUso.DTOs.DTOObservacion
{
    public class ObservacionInputDto
    {
        public DateTime Fecha { get; set; }
        public int PrestamoId { get; set; }
        public int CuerpoCelesteId { get; set; }
    }
}
