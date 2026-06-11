using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using ExcepcionesPropias;
using LogicaAccesoDatos;
using LogicaAplicacion.CasosDeUsoEquipo;
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
        public ICUListadoCamara CUListadoCamara { get; set; }
        public ICUListadoTelescopio CUListadoTelescopio { get; set; }
        public ICUListadoMontura CUListadoMontura   { get; set; }
        public ICUListadoOcular CUListadoOcular { get; set; }
        public ICUListadoSociosPorTelescopio CUListadoSociosPorTelescopio { get; set; }

        public EquipoController(ICUAltaCamara cuAltaCamara, ICUListadoSensor cuListadoSensores, ICUAltaTelescopio cUAltaTelescopio, ICUListadoTipoMontura cUListadoTipoMontura, ICUAltaMontura cUAltaMontura, ICUAltaOcular cUAltaOcular, ICUListadoEquipo cUListadoEquipo, ICUDeleteEquipo cuDeleteEquipo, ICUBuscarEquipo cUBuscarEquipo, ICUModificarEquipo cUModificarEquipo, ICUListadoCamara cUListadoCamara, ICUListadoTelescopio cUListadoTelescopio, ICUListadoMontura cUListadoMontura, ICUListadoOcular cUListadoOcular, ICUListadoSociosPorTelescopio cUListadoSociosPorTelescopio)
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
            CUListadoCamara = cUListadoCamara;
            CUListadoTelescopio = cUListadoTelescopio;
            CUListadoMontura = cUListadoMontura;
            CUListadoOcular = cUListadoOcular;
            CUListadoSociosPorTelescopio = cUListadoSociosPorTelescopio;
        }

        // ----------------------------------------GET SENSORES--------------------------------------
        [HttpGet("sensores")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetSensores()
        {
            return Ok(CUListadoSensores.Ejecutar());
        }
        // ----------------------------------------GET MONTURAS--------------------------------------

        // GET api/equipo/tiposmontura
        [HttpGet("tiposmontura")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetTiposMontura()
        {
            return Ok(CUListadoTipoMontura.Ejecutar());
        }

        // ----------------------------------------LISTADO DE CAMARAS--------------------------------------
        // GET api/equipo/                
        [HttpGet("listadoCamaras")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetCamaras()
        {
            try
            {
                IEnumerable<DTOListadoCamara> dtoCamara = CUListadoCamara.Ejecutar();
                return Ok(dtoCamara);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        // ----------------------------------------GET TELESCOPIOS--------------------------------------

        [HttpGet("listadoTelescopios")]
        public IActionResult GetTelescopios()
        {
            try
            {
                IEnumerable<DTOListadoTelescopio> dtoTelescopio = CUListadoTelescopio.Ejecutar();
                return Ok(dtoTelescopio);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

        }
        // ----------------------------------------GET MONTURAS--------------------------------------

        [HttpGet("listadoMonturas")]
        public IActionResult GetMonturas()
        {
            try
            {
                IEnumerable<DTOListadoMontura> dtoMontura = CUListadoMontura.Ejecutar();
                return Ok(dtoMontura);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

        }
        // ----------------------------------------GET Get Socios Por Telescopio--------------------------------------

        [HttpGet("sociosPorTelescopio/{id}")]
        public IActionResult GetSociosPorTelescopio(int id)
        {
            try
            {
                IEnumerable<DTOListadoUsuario> dto = CUListadoSociosPorTelescopio.Ejecutar(id);
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        // ----------------------------------------GET OCULARES--------------------------------------

        [HttpGet("listadoOculares")]
        public IActionResult GetOculares()
        {
            try
            {
                IEnumerable<DTOListadoOcular> dtoOcular = CUListadoOcular.Ejecutar();
                return Ok(dtoOcular);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

        }

        // ----------------------------------------GET EQUIPOS--------------------------------------
        // GET: api/<EquipoController> LISTADO DE EQUIPO   
        // GET: api/equipo
        [HttpGet("listadoEquipo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetEquipos()
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
        // ----------------------------------------BUSCAR EQUIPOS--------------------------------------

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
        // ----------------------------------------CREATE CAMARA--------------------------------------

        // POST api/equipo/camara
        [HttpPost("createCamara")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateCamara([FromBody] DTOCamara dtoCamara)
        {
            try
            {
                CUAltaCamara.Ejecutar(dtoCamara);
                return Ok(dtoCamara);
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

        // ----------------------------------------CREATE TELESCOPIO--------------------------------------

        [HttpPost("createTelescopio")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateTelescopio([FromBody] DTOTelescopio dtoTelescopio)
        {
            try
            {
                CUAltaTelescopio.Ejecutar(dtoTelescopio);
                return Ok(dtoTelescopio);
                
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

        // ----------------------------------------CREATE MONTURA--------------------------------------

        [HttpPost("createMontura")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateMontura([FromBody] DTOMontura dtoMontura)
        {
            try
            {
                CUAltaMontura.Ejecutar(dtoMontura);
                return Ok(dtoMontura);
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

        // ----------------------------------------CREATE OCULAR--------------------------------------

        [HttpPost("createOcular")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateOcular([FromBody] DTOOcular dtoOcular)
        {
            try
            {
                try
                {
                    CUAltaOcular.Ejecutar(dtoOcular);
                    return Ok(dtoOcular);
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
                    //return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
                    return StatusCode(500, "Error");
                }
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
        //---------------------------------------------------EDIT----------------------------------
        // PUT api/equipo/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Edit(int id, [FromBody] DTOEquipo dtoEquipo)
        {
            try
            {
                CUModificarEquipo.Ejecutar(id, dtoEquipo);
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

        // -----------------------------------------------DELETE -------------------------------------------------
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