using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        public ICUListadoEquipo CUListadoEquipo { get; set; }
        
        
        public EquipoController (ICUListadoEquipo cuListadoEquipo)
        {
            cuListadoEquipo = CUListadoEquipo;
        }

        // GET: api/<EquipoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<DTOEquipo> dtoEquipo = new List<DTOEquipo>();
                return Ok(dtoEquipo);
            }catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
            
        }

        //cambiar lo que devuelv caa metodo(firma) por Iactionresult y copiar solo lo del post de cada metodo

        // GET api/<EquipoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EquipoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EquipoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EquipoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
