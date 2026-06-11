using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using ExcepcionesPropias;
using LogicaAplicacion.CasosDeUsoEnum;
using LogicaAplicacion.CasosDeUsoEquipo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Autenticacion;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public ICULoginUsuario CULoginUsuario { get; set; }
        public ICUAltaUsuario CUAltaUsuario { get; set; }
        public ICUListadoCoordinadores CUListadoCoordinadores { get; set; }
        public ICUListadoUsuario CUListadoUsuarios { get; set; }
        public ICUListadoSocios CUListadoSocios { get; set; }
        public ICUListadoSociosPorTelescopio CUListadoSociosPorTelescopio { get; set; }
        public ICUListadoRol CUListadoRol { get; set; }
        public UsuarioController(ICULoginUsuario cuLoginUsuario, ICUAltaUsuario cuAltaUsuario, ICUListadoCoordinadores cuListadoCoordinadores, ICUListadoUsuario cuListadoUsuarios, ICUListadoSocios cuListadoSocios, ICUListadoSociosPorTelescopio cuListadoSociosPorTelescopio, ICUListadoRol cuListadoRol)
        {
            CULoginUsuario = cuLoginUsuario;
            CUAltaUsuario = cuAltaUsuario;
            CUListadoCoordinadores = cuListadoCoordinadores;
            CUListadoSocios = cuListadoSocios;
            CUListadoUsuarios = cuListadoUsuarios;
            CUListadoSociosPorTelescopio = cuListadoSociosPorTelescopio;
            CUListadoRol = cuListadoRol;
        }
        //-------------------------------------------LOGIN USUARIOS-------------------------------------------

        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOUsuarioLogin dtoLogin)
        {
            DTOUsuarioLogueado dtoUsuarioLogueado = new DTOUsuarioLogueado();
            try
            {
                // Llamamos a la firma existente del caso de uso
                var dto = CULoginUsuario.Ejecutar(dtoLogin.Email, dtoLogin.Contrasenia);

                // dto (DTOUsuario) puede traer Email y Rol según la implementación actual.
                dtoUsuarioLogueado.Email = dto.Email;
                dtoUsuarioLogueado.Rol = dto.Rol?.ToString();
                dtoUsuarioLogueado.NombreUsuario = dto.NombreUsu ?? dto.Email;

                dtoUsuarioLogueado.Token = ManejadorToken.CrearToken(dtoUsuarioLogueado);
                return Ok(dtoUsuarioLogueado);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Error");
            }

        }
        //-------------------------------------------LISTADO USUARIOS-------------------------------------------
        [HttpGet("listadoUsuarios")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetUsuarios()
        {
            try
            {
                IEnumerable<DTOListadoUsuario> dtoUsuario = CUListadoUsuarios.Ejecutar();
                return Ok(dtoUsuario);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        //-------------------------------------------LISTADO coordinadores-------------------------------------------

        [HttpGet("listadoCoordinadores")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetCoordinadores()
        {
            try
            {
                IEnumerable<DTOCoordinador> dtoCoordi = CUListadoCoordinadores.Ejecutar();
                return Ok(dtoCoordi);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        //-------------------------------------------LISTADO socios-------------------------------------------

        [HttpGet("listadoSocios")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetSocios()
        {
            try
            {
                IEnumerable<DTOSocio> dtoCoordi = CUListadoSocios.Ejecutar();
                return Ok(dtoCoordi);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }





        //-------------------------------------------LISTADO roles-------------------------------------------

        [HttpGet("roles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetRoles()
        {
            return Ok(CUListadoRol.Ejecutar());
        }
        //-------------------------------------------ALTA USUARIOS-------------------------------------------

        [HttpPost("createUsuario")]
        public IActionResult Create([FromBody] DTOUsuario dtoUsuario)
        {
            try
            {
                CUAltaUsuario.Ejecutar(dtoUsuario);
                return Ok(dtoUsuario);

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