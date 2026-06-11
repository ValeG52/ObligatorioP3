using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using ExcepcionesPropias;
using LogicaAplicacion.CasosDeUsoEquipo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        public ICUListadoPrestamoById CUListadoPrestamoById { get; set; }
        public ICUListadoPrestamo CUListadoPrestamo { get; set; }
        public ICUAltaPrestamo CUAltaPrestamo { get; set; }
        public ICUModificarPrestamo CUModificarPrestamo { get; set; }
        public ICUListadoPrestamosEntreFechas CUListadoPrestamosEntreFechas { get; set; }
        public ICUListarPrestamosVigentesUsuario CUListarPrestamosVigentesUsuario { get; set; }
        public ICUBuscarPrestamo CUBuscarPrestamo { get; set; }
        public PrestamoController(ICUListadoPrestamoById cUListadoPrestamo, ICUAltaPrestamo cUAltaPrestamo, ICUModificarPrestamo cUModificarPrestamo, ICUListadoPrestamosEntreFechas cUListadoPrestamosEntreFechas, ICUListarPrestamosVigentesUsuario cUListarPrestamosVigentesUsuario, ICUBuscarPrestamo cUBuscarPrestamo, ICUListadoPrestamo cuListadoPrestamo)
        {
            CUListadoPrestamoById = cUListadoPrestamo;
            CUAltaPrestamo = cUAltaPrestamo;
            CUModificarPrestamo = cUModificarPrestamo;
            CUListadoPrestamosEntreFechas = cUListadoPrestamosEntreFechas;
            CUListarPrestamosVigentesUsuario = cUListarPrestamosVigentesUsuario;
            CUBuscarPrestamo = cUBuscarPrestamo;
            CUListadoPrestamo = cuListadoPrestamo;
        }

        
        
        
        // -------------------------------------------------------POST api/Prestamo/create
        [HttpPost("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreatePrestamo([FromBody] DTOPrestamo dtoPrestamo)
        {
            try
            {
                
                CUAltaPrestamo.Ejecutar(dtoPrestamo);
                return Ok(dtoPrestamo);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }


        // ----------------------------------------LISTADO Prestamo--------------------------------------

        [HttpGet("listadoPrestamo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetPrestamos()
        {
            try
            {
                IEnumerable<DTOListadoPrestamo> dtoPrestamo = CUListadoPrestamo.Ejecutar();
                return Ok(dtoPrestamo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }
        // ----------------------------------------Prestamos Vigentes DEL Usuario--------------------------------------

        [HttpGet("listadoPrestamosVigentesUsuario/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetPrestamosVigentesUsuario(int id)
        {
            try
            {
                IEnumerable<DTOListadoPrestamo> dtoPrestamo = CUListarPrestamosVigentesUsuario.Ejecutar(id, DateTime.Now);
                return Ok(dtoPrestamo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }
        // ----------------------------------------Prestamos Entre Fechas--------------------------------------

        [HttpGet("listadoPrestamosEntreFechas/{idSocio}/{mes}/{anio}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetPrestamosEntreFechas(int idSocio, int mes, int anio)
        {
            try
            {
                IEnumerable<DTOListadoPrestamo> prestamos = CUListadoPrestamosEntreFechas.Ejecutar(idSocio, mes, anio);
                if (prestamos == null || !prestamos.Any())
                {
                    return NotFound($"No se encontraron préstamos para el socio {idSocio} en {mes}/{anio}.");
                }
                return Ok(prestamos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        // ----------------------------------------Devolver Prestamo--------------------------------------

        [HttpPost("devolver/{idPrestamo}/{idCoordinador}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DevolverPrestamo(int idPrestamo, int idCoordinador)
        {
            try
            {
                CUModificarPrestamo.Ejecutar(idPrestamo, idCoordinador);
                return Ok();
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
