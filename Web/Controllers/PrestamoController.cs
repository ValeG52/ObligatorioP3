
using DTOs.DTOEquipos;
using DTOs.DTOPrestamos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class PrestamoController : Controller
    {
        
        private string url = "";
        public PrestamoController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "Prestamo";
        }
        public ActionResult Index()
        {
            IEnumerable<DTOListadoPrestamo> equiposDTO = new List<DTOListadoPrestamo>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(url);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> datos = contenido.ReadAsStringAsync();
                    datos.Wait();
                    string resultado = datos.Result;
                    equiposDTO = JsonConvert.DeserializeObject<IEnumerable<DTOListadoPrestamo>>(resultado);
                }

            }
            catch (Exception ex) { }
            return View(equiposDTO);
        }
        public ActionResult Create()
        {
            DTOPrestamo dtoPrestamo = new DTOPrestamo();
            try
            {
                //listar lso equipos
            }
            catch (Exception ex) 
            { 
                
            }

            return View(dtoPrestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOPrestamo dtoPrestamo)
        {
            try
            {

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> datosAEnviar = client.PostAsJsonAsync(url, dtoPrestamo);
                datosAEnviar.Wait();
                HttpResponseMessage respuesta = datosAEnviar.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> datos = contenido.ReadAsStringAsync();
                    datos.Wait();
                    string mensaje = datos.Result;
                    ViewBag.Mensaje = mensaje;
                }
            }
            catch
            {


            }
            return View(dtoPrestamo);
        }
        
    }
}
