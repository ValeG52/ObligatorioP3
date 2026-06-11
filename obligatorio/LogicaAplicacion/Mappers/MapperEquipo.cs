using CasosDeUso.DTOs.DTOEquipos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;
using LogicaNegocio.Enumerados;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

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
                NameTipoEquipo = "Camara",
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
                NameTipoEquipo = "Telescopio",

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
                NameTipoEquipo = "Montura",


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
                NameTipoEquipo = "Ocular",
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
            if (dtoEquipo == null)
            {
                throw new ArgumentNullException("Los datos no son correctos");
            }


            equipo.Marca = dtoEquipo.Marca;
            equipo.Modelo = dtoEquipo.Modelo;
            equipo.Stock = dtoEquipo.Stock;
        }

        public static List<DTOListadoCamara> ListadoCamaraToDTOListadoCamara(IEnumerable<Camara> camaras)
        {
            List<DTOListadoCamara> listadoCamaras = new List<DTOListadoCamara>();
            listadoCamaras = camaras.Select(a => new DTOListadoCamara()
            {
                Id = a.Id,
                Marca = a.Marca,
                Modelo = a.Modelo,
            }).ToList();
            return listadoCamaras;
        }
        public static List<DTOListadoTelescopio> ListadoTelescopioToDTOListadoTelescopio(IEnumerable<Telescopio> telescopios)
        {
            List<DTOListadoTelescopio> listadoTelescopios = new List<DTOListadoTelescopio>();
            listadoTelescopios = telescopios.Select(a => new DTOListadoTelescopio()
            {
                Id = a.Id,
                Marca = a.Marca,
                Modelo = a.Modelo,
            }).ToList();
            return listadoTelescopios;
        }
        public static List<DTOListadoMontura> ListadoMonturaToDTOListadoMontura(IEnumerable<Montura> monturas)
        {
            List<DTOListadoMontura> listadoMonturas = new List<DTOListadoMontura>();
            listadoMonturas = monturas.Select(a => new DTOListadoMontura()
            {
                Id = a.Id,
                Marca = a.Marca,
                Modelo = a.Modelo,
            }).ToList();
            return listadoMonturas;
        }
        public static List<DTOListadoOcular> ListadoOcularToDTOListadoOcular(IEnumerable<Ocular> oculars)
        {

            List<DTOListadoOcular> listadooculares = new List<DTOListadoOcular>();
            listadooculares = oculars.Select(a => new DTOListadoOcular()
            {
                Id = a.Id,
                Marca = a.Marca,
                Modelo = a.Modelo,
            }).ToList();
            return listadooculares;

        }
    }
}
