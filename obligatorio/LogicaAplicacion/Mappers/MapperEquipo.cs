using CasosDeUso.DTOs.DTOEquipos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;
using LogicaNegocio.Enumerados;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            
            return new Camara()
            {
                Marca = dtoCamara.Marca,
                Modelo = dtoCamara.Modelo,
                Stock = dtoCamara.Stock,
                
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
            
            return new Telescopio()
            {
                Marca = dtoTelescopio.Marca,
                Modelo = dtoTelescopio.Modelo,
                Stock = dtoTelescopio.Stock,
               
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
            
            return new Montura()
            {
                Marca = dtoMontura.Marca,
                Modelo = dtoMontura.Modelo,
                Stock = dtoMontura.Stock,
                
                TipoMontura = dtoMontura.TipoMontura,
                Carga = dtoMontura.Carga,
                Computarizado = dtoMontura.Computarizado,
            };
        }

        public static Ocular DTOOcularToOcular(DTOOcular dtoOcular)
        {
            if (dtoOcular == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            
            return new Ocular()
            {
                Marca = dtoOcular.Marca,
                Modelo = dtoOcular.Modelo,
                Stock = dtoOcular.Stock,
                
                Diametro = dtoOcular.Diametro,
                AnguloVision = dtoOcular.AnguloVision,

            };
        }

        public static IEnumerable<DTOEquipo> ListEquipoToListDTOEquipo(List<Equipo> equipos)
        {
            List<DTOEquipo> dtoEquipos = new List<DTOEquipo>();
            dtoEquipos = equipos.Select(e => new DTOEquipo()
            {
                Id = e.Id,
                Marca = e.Marca,
                Modelo = e.Modelo,
                Stock = e.Stock,
                TipoEquipo = e.GetType().Name
            }).ToList();
            return dtoEquipos;
        }

        public static DTOEquipo EquipoToListDTOEquipo(Equipo e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("El país no puede ser nulo");
            }
            return new DTOEquipo()
            {
                Id = e.Id,
                Marca = e.Marca,
                Modelo = e.Modelo,
                Stock = e.Stock,
                TipoEquipo = e.GetType().Name
            };
        }

        public static void DTOEquipoToEquipo(DTOEquipo dtoEquipo, Equipo equipo)
        {
            if (dtoEquipo == null )
            {
                throw new ArgumentNullException("Los datos no son correctos");
            }


            equipo.Marca = dtoEquipo.Marca;
            equipo.Modelo = dtoEquipo.Modelo;
            equipo.Stock = dtoEquipo.Stock;
        }

        public static List<DTOListadoCamara> ListadoCamaraToDTOListadoCamara()
    }
}
