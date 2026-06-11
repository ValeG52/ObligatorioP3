
using DTOs.DTOEquipos;
using DTOs.DTOPrestamos;
using DTOs.DTOUsuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class PrestamoController : Controller
    {

        private string urlPrestamo = "";
        private string urlEquipo = "";
        private string urlUsuarios = "";

        public PrestamoController(IConfiguration configuration)
        {
            string urlBase = configuration.GetValue<string>("urlBase");

            urlPrestamo = urlBase + "Prestamo";
            urlEquipo = urlBase + "Equipo";
            urlUsuarios = urlBase + "Usuario";
        }
        public ActionResult Index()
        {
            IEnumerable<DTOListadoPrestamo> equiposDTO = new List<DTOListadoPrestamo>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlPrestamo);
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
        //--------------------------------------ALTA PRESTAMO
        // GET: Prestamo/Create
        public ActionResult Create()
        {
            DTOPrestamo dtoPrestamo = new DTOPrestamo();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> usuarios = client.GetAsync(urlUsuarios + "/usuarios");
                Task<HttpResponseMessage> camaras = client.GetAsync(urlEquipo + "/camaras");// varias tareas para acceder a los distintos metodos
                Task<HttpResponseMessage> telescopios = client.GetAsync(urlEquipo + "/telescopios");
                Task<HttpResponseMessage> monturas = client.GetAsync(urlEquipo + "/monturas");
                Task<HttpResponseMessage> oculares = client.GetAsync(urlEquipo + "/oculares");
                usuarios.Wait();
                camaras.Wait();
                telescopios.Wait();
                monturas.Wait();
                oculares.Wait();
                HttpResponseMessage respuestaUsuarios = usuarios.Result;
                HttpResponseMessage respuestaCamaras = camaras.Result;
                HttpResponseMessage respuestaTelescopios = telescopios.Result;
                HttpResponseMessage respuestaMonturas = monturas.Result;
                HttpResponseMessage respuestaOculares = oculares.Result;
                if (respuestaUsuarios.IsSuccessStatusCode)
                {
                    Console.WriteLine(respuestaMonturas.StatusCode);
                    string datosUsuario = respuestaUsuarios.Content.ReadAsStringAsync().Result;
                    dtoPrestamo.Usuarios = JsonConvert.DeserializeObject<IEnumerable<DTOListadoUsuario>>(datosUsuario);
                }
                
               if (respuestaCamaras.IsSuccessStatusCode)
                {
                    
                    string datosCamaras = respuestaCamaras.Content.ReadAsStringAsync().Result;
                    dtoPrestamo.Camaras = JsonConvert.DeserializeObject<IEnumerable<DTOListadoCamara>>(datosCamaras);
                }

                if (respuestaTelescopios.IsSuccessStatusCode)
                {
                    string datosTelescopios = respuestaTelescopios.Content.ReadAsStringAsync().Result;
                    dtoPrestamo.Telescopios = JsonConvert.DeserializeObject<IEnumerable<DTOListadoTelescopio>>(datosTelescopios);
                }

                if (respuestaMonturas.IsSuccessStatusCode)
                {
                    string datosMonturas = respuestaMonturas.Content.ReadAsStringAsync().Result;
                    dtoPrestamo.Monturas = JsonConvert.DeserializeObject<IEnumerable<DTOListadoMontura>>(datosMonturas);
                }

                if (respuestaOculares.IsSuccessStatusCode)
                {
                    string datosOculares = respuestaOculares.Content.ReadAsStringAsync().Result;
                    dtoPrestamo.Oculares = JsonConvert.DeserializeObject<IEnumerable<DTOListadoOcular>>(datosOculares);
                }


            }
            catch (Exception ex)
            {

            }
            ViewBag.Debug =
    $"Camaras: {dtoPrestamo.Camaras?.Count() ?? 0} - " +
    $"Telescopios: {dtoPrestamo.Telescopios?.Count() ?? 0} - " +
    $"Monturas: {dtoPrestamo.Monturas?.Count() ?? 0} - " +
    $"Oculares: {dtoPrestamo.Oculares?.Count() ?? 0} - " +
    $"Usuarios: {dtoPrestamo.Usuarios?.Count() ?? 0}";

            return View(dtoPrestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DTOPrestamo dtoPrestamo)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage respuesta = client.PostAsJsonAsync(urlPrestamo + "/create", dtoPrestamo).Result; 

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = respuesta.Content.ReadAsStringAsync().Result;

            // si falla, tenés que volver a cargar las listas
            return View(dtoPrestamo);
        }

        //------------------------------ELIMINAR PRESTAMO

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestamoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //------------------------------EDITAR PRESTAMO
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestamoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
