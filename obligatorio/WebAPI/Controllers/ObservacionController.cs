using CasosDeUso.DTOs.DTOCuerpoCeleste;
using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOObservacion;
using CasosDeUso.InterfacesCasosDeUso.ICUCuerpoCeleste;
using CasosDeUso.InterfacesCasosDeUso.ICUObservacion;
using ExcepcionesPropias;
using LogicaAplicacion.CasosDeUsoEquipo;
using LogicaNegocio.Enumerados;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionController : ControllerBase
    {
        public ICUAltaObservacion CUAltaObservacion { get; set; }
        public ICUListarCuerpoCelesteEnRanking CUListarCuerpoCelesteEnRanking { get; set; }
        public ObservacionController(ICUAltaObservacion cUAltaObservacion)
        {
            CUAltaObservacion = cUAltaObservacion;
        }



        
        // ----------------------------------------CONFRIMAR ALTA --------------------------------------

        // POST api/Observacion/confirmar
        [HttpPost("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult ConfirmarAlta([FromBody] DTOObservacion dto)
        {
            try
            {
                CUAltaObservacion.Ejecutar(dto.Fecha, dto.CuerpoCeleste , dto.Prestamo);
                return Ok(dto);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
        // ----------------------------------------RANKING--------------------------------------

        [HttpGet("ranking")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetRanking()
        {
            try
            {
                IEnumerable<DTOListadoCuerpoCeleste> lista= CUListarCuerpoCelesteEnRanking.Ejecutar();
                return Ok(lista);
            }
            catch
            {
                return StatusCode(500, "Error");
            }
        }

       
    }
}
