using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using ExcepcionesPropias;
using LogicaAccesoDatos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    //cambiar lo que devuelv caa metodo(firma) por Iactionresult y copiar solo lo del post de cada metodo
    public class EquipoController : ControllerBase
    {
        public ICUAltaCamara CUAltaCamara { get; set; }
        public ICUListadoSensor CUListadoSensores { get; set; }
        public ICUAltaTelescopio CUAltaTelescopio { get; set; }
        public ICUListadoTipoMontura CUListadoTipoMontura { get; set; }
        public ICUAltaMontura CUAltaMontura { get; set; }
        public ICUAltaOcular CUAltaOcular { get; set; }
        public ICUListadoEquipo CUListadoEquipo { get; set; }
        public ICUDeleteEquipo CUDeleteEquipo { get; set; }
        public ICUBuscarEquipo CUBuscarEquipo { get; set; }
        public ICUModificarEquipo CUModificarEquipo { get; set; }
        public EquipoController(ICUAltaCamara cuAltaCamara, ICUListadoSensor cuListadoSensores, ICUAltaTelescopio cUAltaTelescopio, ICUListadoTipoMontura cUListadoTipoMontura, ICUAltaMontura cUAltaMontura, ICUAltaOcular cUAltaOcular, ICUListadoEquipo cUListadoEquipo, ICUDeleteEquipo cuDeleteEquipo, ICUBuscarEquipo cUBuscarEquipo, ICUModificarEquipo cUModificarEquipo)
        {
            CUAltaCamara = cuAltaCamara;
            CUListadoSensores = cuListadoSensores;
            CUAltaTelescopio = cUAltaTelescopio;
            CUListadoTipoMontura = cUListadoTipoMontura;
            CUAltaMontura = cUAltaMontura;
            CUAltaOcular = cUAltaOcular;
            CUListadoEquipo = cUListadoEquipo;
            CUDeleteEquipo = cuDeleteEquipo;
            CUBuscarEquipo = cUBuscarEquipo;
            CUModificarEquipo = cUModificarEquipo;
        }

        // GET api/equipo/sensores
        [HttpGet("sensores")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
       

        // GET api/equipo/tiposmontura
        [HttpGet("tipomontura")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetTiposMontura()
        {
            return Ok(CUListadoTipoMontura.Ejecutar());
        }

        // GET api/equipo/form/camara
        [HttpGet("form/camara")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            DTOCamara dto = new DTOCamara();
            try
            {
                dto.Sensores = CUListadoSensores.Ejecutar();
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        // GET: api/<EquipoController> LISTADO DE EQUIPO   
        // GET: api/equipo
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetEquipo()
        {
            try
            {
                IEnumerable<DTOEquipo> dtoEquipo = CUListadoEquipo.Ejecutar();
                return Ok(dtoEquipo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        // GET api/equipo/{id}
        [HttpGet("{id}", Name = "FindById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                DTOEquipo dtoEquipo = CUBuscarEquipo.Ejecutar(id);
                return Ok(dtoEquipo);
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

        // POST api/equipo/camara
        [HttpPost("camara")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateCamara([FromBody] DTOCamara dtoCamara)
        {
            try
            {
                int id = CUAltaCamara.Ejecutar(dtoCamara);
                return CreatedAtRoute("FindById", new { id = id }, dtoCamara);
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

        // POST api/equipo/telescopio
        [HttpPost("telescopio")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateTelescopio([FromBody] DTOTelescopio dtoTelescopio)
        {
            try
            {
                int id = CUAltaTelescopio.Ejecutar(dtoTelescopio);
                return CreatedAtRoute("FindById", new { id = id }, dtoTelescopio);
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

        // POST api/equipo/montura
        [HttpPost("montura")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateMontura([FromBody] DTOMontura dtoMontura)
        {
            try
            {
                int id = CUAltaMontura.Ejecutar(dtoMontura);
                return CreatedAtRoute("FindById", new { id = id }, dtoMontura);
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

        // POST api/equipo/ocular
        [HttpPost("ocular")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateOcular([FromBody] DTOOcular dtoOcular)
        {
            try
            {
                int id = CUAltaOcular.Ejecutar(dtoOcular);
                return CreatedAtRoute("FindById", new { id = id }, dtoOcular);
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

        // PUT api/equipo/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] DTOEquipo dtoEquipo)
        {
            try
            {
                CUModificarEquipo.Ejecutar(id, dtoEquipo);
                return NoContent();
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

        // DELETE api/equipo/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                CUDeleteEquipo.Ejecutar(id);
                return NoContent();
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