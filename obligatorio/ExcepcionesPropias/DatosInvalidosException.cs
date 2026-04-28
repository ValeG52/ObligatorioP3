using System;
using System.Collections.Generic;
using System.Text;

namespace ExcepcionesPropias
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException() { }
        public DatosInvalidosException(string message) : base(message) { }
       
       
    }
}
