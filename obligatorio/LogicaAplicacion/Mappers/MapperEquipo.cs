using CasosDeUso.DTOs.DTOEquipos;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.Mappers
{
    public class MapperEquipo
    {
        public static Camara DTOCamaraToCamara(DTOCamara dtoCamara)
        {
            if (dtoCamara == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            //List<int> camaraId = dtoCamara.Id.ToList();
            return new Camara()
            {
                Marca = dtoCamara.Marca,
                Modelo = dtoCamara.Modelo,
                Stock = dtoCamara.Stock,
                Estado = dtoCamara.Estado,
                Sensor = dtoCamara.Sensor,              
                TamPixel = dtoCamara.TamPixel,
                Resolucion = dtoCamara.Resolucion,
            };
        }

        public static Telescopio DTOTelescopioToTelescopio(DTOTelescopio dtoTelescopio)
        {
            if (dtoTelescopio == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            //List<int> telescopioId = dtoTelescopio.Id.ToList();
            return new Telescopio()
            {
                Marca = dtoTelescopio.Marca,
                Modelo = dtoTelescopio.Modelo,
                Stock = dtoTelescopio.Stock,
                Estado = dtoTelescopio.Estado,
                Apertura = dtoTelescopio.Apertura,
                RelFocal = dtoTelescopio.RelFocal,
                DisFocal = dtoTelescopio.DisFocal,
            };
        }

        public static Montura DTOMonturaToMontura(DTOMontura dtoMontura)
        {
            if (dtoMontura == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            //List<int> monturaId = dtoMontura.Id.ToList();
            return new Montura()
            {
                Marca = dtoMontura.Marca,
                Modelo = dtoMontura.Modelo,
                Stock = dtoMontura.Stock,
                Estado = dtoMontura.Estado,
                TipoMontura = dtoMontura.TipoMontura,
                Carga = dtoMontura.Carga,
                Computarizado = dtoMontura.Computarizado,
            };
        }

    }
}
