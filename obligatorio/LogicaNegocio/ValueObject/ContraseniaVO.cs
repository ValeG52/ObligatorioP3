using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObject
{
    [Owned]

    public class ContraseniaVO
    {

        public string Contrasenia { get; private set; }   

        public ContraseniaVO(string contrasenia)
        {
            Contrasenia = contrasenia;
            Validar(contrasenia);
        }


        public void Validar(string contrasenia)
        {
            if (string.IsNullOrEmpty(contrasenia) || contrasenia.Length < 8)
            {
                throw new DatosInvalidosException("La contraseña debe tener al menos 8 caracteres.");
            }
            if (!Regex.IsMatch(contrasenia, @"[A-Z]"))
            {
                throw new DatosInvalidosException("Debe tener al menos una mayúscula.");
            }

            if (!Regex.IsMatch(contrasenia, @"[a-z]"))
            {
                throw new DatosInvalidosException("Debe tener al menos una minúscula.");
            }

            if (!Regex.IsMatch(contrasenia, @"[0-9]"))
            {
                throw new DatosInvalidosException("Debe tener al menos un número.");
            }

            if (!Regex.IsMatch(contrasenia, @"[\W_]"))
            {
                throw new DatosInvalidosException("Debe tener al menos un caracter especial.");
            }
        }  

    }
}