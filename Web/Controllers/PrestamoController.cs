
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
        //--------------------------------------ALTA PRESTAMO
        public ActionResult Create()
        {
            DTOPrestamo dtoPrestamo = new DTOPrestamo();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(url + "/create");
                Task<HttpResponseMessage> tarea = client.GetAsync(url + "Equipo/create");// varias tareas para acceder a los distintos metodos 
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> datosRespuesta = contenido.ReadAsStringAsync();
                    datosRespuesta.Wait();
                    string datos = datosRespuesta.Result;
                    dtoPrestamo.Camaras = JsonConvert.DeserializeObject<IEnumerable<DTOListadoCamara>>(datos);
                    dtoPrestamo.Telescopios = JsonConvert.DeserializeObject<IEnumerable<DTOListadoTelescopio>>(datos);
                    dtoPrestamo.Monturas = JsonConvert.DeserializeObject<IEnumerable<DTOListadoMontura>>(datos);
                    dtoPrestamo.Oculares = JsonConvert.DeserializeObject<IEnumerable<DTOListadoOcular>>(datos);
                }
                else
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> datosRespuesta = contenido.ReadAsStringAsync();
                    datosRespuesta.Wait();
                    string datos = datosRespuesta.Result;
                    ViewBag.Mensaje = datos;
                }

                
            }
            catch (Exception ex)
            {

            }

            return View(dtoPrestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection dtoPrestamo)
        {
            try
            {
                return RedirectToAction(nameof(Index));

            }
            catch
            {

            }
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
