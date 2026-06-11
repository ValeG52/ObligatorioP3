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
        public ICUListadoPrestamo CUListadoPrestamo { get; set; }
        public ICUAltaPrestamo CUAltaPrestamo { get; set; }
        public ICUModificarPrestamo CUModificarPrestamo { get; set; }
        public ICUListadoPrestamosEntreFechas CUListadoPrestamosEntreFechas { get; set; }
        public ICUListarPrestamosVigentesUsuario CUListarPrestamosVigentesUsuario { get; set; }
        public ICUBuscarPrestamo CUBuscarPrestamo { get; set; }
        public PrestamoController(ICUListadoPrestamo cUListadoPrestamo, ICUAltaPrestamo cUAltaPrestamo, ICUModificarPrestamo cUModificarPrestamo, ICUListadoPrestamosEntreFechas cUListadoPrestamosEntreFechas, ICUListarPrestamosVigentesUsuario cUListarPrestamosVigentesUsuario, ICUBuscarPrestamo cUBuscarPrestamo)
        {
            CUListadoPrestamo = cUListadoPrestamo;
            CUAltaPrestamo = cUAltaPrestamo;
            CUModificarPrestamo = cUModificarPrestamo;
            CUListadoPrestamosEntreFechas = cUListadoPrestamosEntreFechas;
            CUListarPrestamosVigentesUsuario = cUListarPrestamosVigentesUsuario;
            CUBuscarPrestamo = cUBuscarPrestamo;
        }

        
        
        
        // POST api/Prestamo/create
        [HttpPost("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreatePrestamo([FromBody] DTOPrestamo dtoPrestamo)
        {
            try
            {
                //int idUsuario = url de la clase;
                //dtoPrestamo.UsuarioId = idUsuario;
                 
                CUAltaPrestamo.Ejecutar(dtoPrestamo);
                return CreatedAtRoute("FindById", dtoPrestamo);
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
       
        
        
        
        
        
        
        // GET: api/<PrestamoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PrestamoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrestamoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrestamoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrestamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
