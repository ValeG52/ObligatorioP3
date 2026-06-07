using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasosDeUso.DTOs.DTOCuerpoCeleste
{
    public class DTORankingCuerpoCeleste
    {
       public string Nombre { get; set; }
       public Tipo Tipo { get; set; }
       public string CantidadObservaciones { get; set; }
    }
}
