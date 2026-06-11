
using CasosDeUso.DTOs.DTOUsuarios;
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

        // GET: Prestamo/Vigentes
        public ActionResult Vigentes()
        {
            // cargar select de socios
            IEnumerable<DTOSocio> socios = new List<DTOSocio>();
            IEnumerable<DTOCoordinador> coordinadores = new List<DTOCoordinador>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlUsuarios + "/listadoSocios");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string datos = respuesta.Content.ReadAsStringAsync().Result;
                    socios = JsonConvert.DeserializeObject<IEnumerable<DTOSocio>>(datos);
                }
                // cargar select de coordinadores
                Task<HttpResponseMessage> tareaCoord = client.GetAsync(urlUsuarios + "/listadoCoordinadores");
                tareaCoord.Wait();
                HttpResponseMessage respCoord = tareaCoord.Result;
                if (respCoord.IsSuccessStatusCode)
                {
                    string datosCoord = respCoord.Content.ReadAsStringAsync().Result;
                    coordinadores = JsonConvert.DeserializeObject<IEnumerable<DTOCoordinador>>(datosCoord);
                }
            }
            catch { }

            ViewBag.Socios = socios;
            ViewBag.Coordinadores = coordinadores;
            // devolver un modelo similar al Create para reutilizar la lista de socios
            DTOPrestamo dto = new DTOPrestamo();
            dto.Socios = socios;
            return View(dto);
        }

        [HttpGet]
        public ActionResult GetPrestamosVigentesUsuario(int id)
        {
            IEnumerable<DTOListadoPrestamo> prestamosDTO = new List<DTOListadoPrestamo>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlPrestamo + $"/listadoPrestamosVigentesUsuario/{id}");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    prestamosDTO = JsonConvert.DeserializeObject<IEnumerable<DTOListadoPrestamo>>(resultado);
                }
            }
            catch { }

            return PartialView("_PrestamosVigentesTable", prestamosDTO);
        }

        [HttpPost]
        public ActionResult Devolver(int idPrestamo, int idCoordinador)
        {
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.PostAsync(urlPrestamo + $"/devolver/{idPrestamo}/{idCoordinador}", null);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Vigentes));
                }
                else
                {
                    TempData["Error"] = respuesta.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Vigentes));
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Vigentes));
            }
        }
        public ActionResult Index()
        {
            IEnumerable<DTOListadoPrestamo> prestamosDTO = new List<DTOListadoPrestamo>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlPrestamo + "/listadoPrestamo");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> datos = contenido.ReadAsStringAsync();
                    datos.Wait();
                    string resultado = datos.Result;
                    prestamosDTO = JsonConvert.DeserializeObject<IEnumerable<DTOListadoPrestamo>>(resultado);
                }

            }
            catch (Exception ex) { }
            return View(prestamosDTO);
        }

        // GET: Prestamo/PorMes
        public ActionResult PorMes()
        {
            // cargar lista de socios para permitir buscar por socio (opcional)
            IEnumerable<DTOSocio> socios = new List<DTOSocio>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlUsuarios + "/listadoSocios");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string datos = respuesta.Content.ReadAsStringAsync().Result;
                    socios = JsonConvert.DeserializeObject<IEnumerable<DTOSocio>>(datos);
                }
            }
            catch { }
            ViewBag.Socios = socios;
            return View(new List<DTOListadoPrestamo>());
        }

        // POST: Prestamo/PorMes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PorMes(int mes, int anio, int? idSocio)
        {
            try
            {
                // usar el socio seleccionado si se pasó, si no usar el usuario en session
                int userId = idSocio ?? (HttpContext.Session.GetInt32("UsuarioId") ?? 0);
                if (userId == 0)
                {
                    ViewBag.Error = "No hay usuario logueado ni socio seleccionado.";
                    return View(new List<DTOListadoPrestamo>());
                }

                // volver a cargar la lista de socios para la vista
                IEnumerable<DTOSocio> socios = new List<DTOSocio>();
                try
                {
                    HttpClient client2 = new HttpClient();
                    Task<HttpResponseMessage> tarea2 = client2.GetAsync(urlUsuarios + "/listadoSocios");
                    tarea2.Wait();
                    HttpResponseMessage resp2 = tarea2.Result;
                    if (resp2.IsSuccessStatusCode)
                    {
                        string datos2 = resp2.Content.ReadAsStringAsync().Result;
                        socios = JsonConvert.DeserializeObject<IEnumerable<DTOSocio>>(datos2);
                    }
                }
                catch { }
                ViewBag.Socios = socios;

                HttpClient client = new HttpClient();
                // Llamada al API para obtener prestamos entre fechas por usuario
                Task<HttpResponseMessage> tarea = client.GetAsync(urlPrestamo + $"/listadoPrestamosEntreFechas/{userId}/{mes}/{anio}");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                IEnumerable<DTOListadoPrestamo> prestamos = new List<DTOListadoPrestamo>();
                if (respuesta.IsSuccessStatusCode)
                {
                    string datos = respuesta.Content.ReadAsStringAsync().Result;
                    prestamos = JsonConvert.DeserializeObject<IEnumerable<DTOListadoPrestamo>>(datos);
                }

                return View(prestamos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<DTOListadoPrestamo>());
            }
        }
        
        //--------------------------------------ALTA PRESTAMO
        // GET: Prestamo/Create
        public ActionResult Create()
        {
            DTOPrestamo dtoPrestamo = new DTOPrestamo();
            try
            {

                CargarSelect(dtoPrestamo);
                return View(dtoPrestamo);


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

                Task<HttpResponseMessage> tarea = client.PostAsJsonAsync(urlPrestamo + "/create", dtoPrestamo);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
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
                    CargarSelect(dtoPrestamo);
                    return View(dtoPrestamo);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                CargarSelect(dtoPrestamo);
                return View(dtoPrestamo);
            }
        }

        [HttpGet]
        public void CargarSelect(DTOPrestamo dtoPrestamo) 
        {
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> usuarios = client.GetAsync(urlUsuarios + "/listadoSocios");
                Task<HttpResponseMessage> camaras = client.GetAsync(urlEquipo + "/listadoCamaras");// varias tareas para acceder a los distintos metodos
                Task<HttpResponseMessage> telescopios = client.GetAsync(urlEquipo + "/listadoTelescopios");
                Task<HttpResponseMessage> monturas = client.GetAsync(urlEquipo + "/listadoMonturas");
                Task<HttpResponseMessage> oculares = client.GetAsync(urlEquipo + "/listadoOculares");
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
                    dtoPrestamo.Socios = JsonConvert.DeserializeObject<IEnumerable<DTOSocio>>(datosUsuario);
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
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        

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
