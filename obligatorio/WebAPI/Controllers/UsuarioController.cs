using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using ExcepcionesPropias;
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
        public ICUListadoSociosPorTelescopio CUListadoSociosPorTelescopio { get; set; }
        public UsuarioController(ICULoginUsuario cuLoginUsuario, ICUAltaUsuario cuAltaUsuario, ICUListadoCoordinadores cuListadoCoordinadores, ICUListadoUsuario cuListadoUsuarios, ICUListadoSociosPorTelescopio cuListadoSociosPorTelescopio)
        {
            CULoginUsuario = cuLoginUsuario;
            CUAltaUsuario = cuAltaUsuario;
            CUListadoCoordinadores = cuListadoCoordinadores;
            CUListadoUsuarios = cuListadoUsuarios;
            CUListadoSociosPorTelescopio = cuListadoSociosPorTelescopio;
        }

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
        [HttpPost("usuarios")]
        public IActionResult GetUsuarios()
        {
            IEnumerable<DTOListadoUsuario> temas = new List<DTOListadoUsuario>();
            try
            {
                temas = CUListadoUsuarios.Ejecutar();
                return Ok(temas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }

        }
    }
}