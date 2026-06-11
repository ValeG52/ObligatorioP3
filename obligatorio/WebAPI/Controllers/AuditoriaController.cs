using CasosDeUso.InterfacesCasosDeUso.ICUAuditorias;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.DTOs.DTOPrestamos;
using Microsoft.AspNetCore.Mvc;
using CasosDeUso.DTOs.DTOAuditoria;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        public ICUBuscarAuditoriaByID CUBuscarAuditoriaByID { get; set; }
        public ICUListadoAuditoriasById CUListadoAuditoriasById { get; set; }
        public ICUListadoCoordinadores CUListadoCoordinadores { get; set; }
        public ICUListadoPrestamoById CUListadoPrestamoById { get; set; }
        public AuditoriaController(ICUBuscarAuditoriaByID cUBuscarAuditoriaByID, ICUListadoAuditoriasById cUListadoAuditoriasById, ICUListadoCoordinadores cUListadoCoordinadores, ICUListadoPrestamoById cUListadoPrestamoById)
        {
            CUBuscarAuditoriaByID = cUBuscarAuditoriaByID;
            CUListadoAuditoriasById = cUListadoAuditoriasById;
            CUListadoCoordinadores = cUListadoCoordinadores;
            CUListadoPrestamoById = cUListadoPrestamoById;
        }



        // ----------------------------------------DETALLE PRESTAMO--------------------------------------


        // GET api/<AuditoriaController>/detallePrestamo/5
        [HttpGet("detallePrestamo/{id}")]
        public IActionResult GetDetallePrestamo(int id)
        {
            try
            {
                IEnumerable<DTOListadoPrestamo> prestamos = CUListadoPrestamoById.Ejecutar(id);
                return Ok(prestamos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }
        // ----------------------------------------GET COORDINADORES --------------------------------------

        [HttpGet("coordinadores")]
        public IActionResult GetCoordinadores()
        {
            try
            {
                IEnumerable<DTOCoordinador> dto = CUListadoCoordinadores.Ejecutar();
                return Ok(dto);
            }
            catch
            {
                return StatusCode(500, "Error");
            }
        }


        // ----------------------------------------PRESTAMOS POR COORDINADOR --------------------------------------

        [HttpGet("prestamosPorCoordinador/{idCoordinador}")]
        public IActionResult GetPrestamosPorCoordinador(int idCoordinador)
        {
            try
            {
                IEnumerable<DTOListadoPrestamo> dto  = CUListadoPrestamoById.Ejecutar(idCoordinador);
                return Ok(dto);
            }
            catch
            {
                return StatusCode(500, "Error");
            }
        }
        // ----------------------------------------Auditorias Por Prestamo--------------------------------------

        [HttpGet("auditoriasPorPrestamo/{idPrestamo}")]
        public IActionResult GetAuditoriasPorPrestamo(int idPrestamo)
        {
            try
            {
                IEnumerable<DTOAuditoria> dto = CUListadoAuditoriasById.Ejecutar(idPrestamo);
                return Ok(dto);
            }
            catch
            {
                return StatusCode(500, "Error");
            }
        }

    }
}
