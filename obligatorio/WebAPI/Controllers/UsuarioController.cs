using CasosDeUso.InterfacesCasosDeUso;
using ExcepcionesPropias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebAPI.Autenticacion;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public ICULoginUsuario CULoginUsuario { get; set; }
        public UsuarioController(ICULoginUsuario cuLoginUsuario)
        {
            CULoginUsuario = cuLoginUsuario;
        }
        [HttpPost]
        /*public IActionResult Login([FromBody]DTOUsuarioLogin dtoLogin)//hay que crearlo 
        {
            DTOUsuarioLogueado dtoUsuarioLogueado = new DTOUsuarioLogueado;
            try
            {
                dtoUsuarioLogueado = CULoginUsuario.Ejecutar(dtoLogin);
                if (dtoUsuarioLogueado != null)
                {
                    dtoUsuarioLogueado.Token = ManejadorToken.CrearToken(dtoUsuarioLogueado);
                    return OK(dtoUsuarioLogueado);
                }
                else
                {
                    return NotFound("datos incrrectos");
                }

            } catch (DatosInvalidosException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, "Error");
            }
        }*/

    }
