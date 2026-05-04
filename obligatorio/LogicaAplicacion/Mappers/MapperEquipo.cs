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
            List<int> autoresId = dtoCamara.Id.ToList();
            return new Camara()
            {
                FechaPublicacion = dtoLibro.Fecha,
                PrecioSugerido = dtoLibro.Precio,
                TemaId = dtoLibro.TemaId,
                ISBN = dtoLibro.ISBN,
                Titulo = dtoLibro.Titulo,
                Autores = autoresId.Select(a => new Autor()
                {
                    Id = a
                }).ToList()
            };
        }
    }
}
