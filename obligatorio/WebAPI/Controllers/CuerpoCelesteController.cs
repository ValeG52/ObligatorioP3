using CasosDeUso.InterfacesCasosDeUso.ICUCuerpoCeleste;
using CasosDeUso.DTOs.DTOCuerpoCeleste;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuerpoCelesteController : ControllerBase
    {
        public ICUListarCuerpoCeleste CUListarCuerpoCeleste { get; set; }
        public CuerpoCelesteController(ICUListarCuerpoCeleste cUListarCuerpoCeleste)
        {
            CUListarCuerpoCeleste = cUListarCuerpoCeleste;
        }
        // ----------------------------------------LISTADO --------------------------------------

        [HttpGet("listado")]
        public IActionResult GetListado()
        {
            try
            {
                IEnumerable<DTOCuerpoCeleste> lista = CUListarCuerpoCeleste.Ejecutar();
                return Ok(lista);
            }
            catch
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
