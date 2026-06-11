using CasosDeUso.DTOs.DTOObservacion;
using CasosDeUso.DTOs.DTOCuerpoCeleste;
using DTOs.DTOPrestamos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class ObservacionController : Controller
    {
        private string urlPrestamo = "";
        private string urlCuerpoCeleste = "";
        private string urlObservacion = "";

        public ObservacionController(IConfiguration configuration)
        {
            string urlBase = configuration.GetValue<string>("urlBase");
            urlPrestamo = urlBase + "Prestamo";
            urlCuerpoCeleste = urlBase + "CuerpoCeleste";
            urlObservacion = urlBase + "Observacion";
        }
        // GET: ObservacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ObservacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ObservacionController/Create
        public ActionResult Create()
        {
            DTOObservacion model = new DTOObservacion();
            try
            {
                int userId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
                if (userId == 0)
                {
                    ViewBag.Error = "No hay usuario logueado.";
                    ViewBag.Prestamos = new List<DTOListadoPrestamo>();
                }
                else
                {
                    HttpClient client = new HttpClient();
                    Task<HttpResponseMessage> tarea = client.GetAsync(urlPrestamo + $"/listadoPrestamosVigentesUsuario/{userId}");
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string datos = respuesta.Content.ReadAsStringAsync().Result;
                        var prestamos = JsonConvert.DeserializeObject<IEnumerable<DTOListadoPrestamo>>(datos);
                        // filtrar estado EN PRÉSTAMO
                        var filtrados = prestamos.Where(p => string.Equals(p.Estado, "EN PRÉSTAMO", StringComparison.OrdinalIgnoreCase));
                        ViewBag.Prestamos = filtrados;
                    }
                    else
                    {
                        ViewBag.Prestamos = new List<DTOListadoPrestamo>();
                    }
                }

                // cargar cuerpos celestes (ranking/listado)
                HttpClient clientCC = new HttpClient();
                Task<HttpResponseMessage> tareaCC = clientCC.GetAsync(urlCuerpoCeleste + "/listado");
                tareaCC.Wait();
                HttpResponseMessage respCC = tareaCC.Result;
                if (respCC.IsSuccessStatusCode)
                {
                    string datos = respCC.Content.ReadAsStringAsync().Result;
                    var cuerpos = JsonConvert.DeserializeObject<IEnumerable<DTOCuerpoCeleste>>(datos);
                    ViewBag.Cuerpos = cuerpos;
                }
                else
                {
                    ViewBag.Cuerpos = new List<DTOCuerpoCeleste>();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Prestamos = new List<DTOListadoPrestamo>();
                ViewBag.Cuerpos = new List<DTOCuerpoCeleste>();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Evaluar([FromBody] DTOObservacion dto)
        {
            if (dto == null) return BadRequest();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.PostAsJsonAsync(urlObservacion + "/evaluar", dto);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string datos = respuesta.Content.ReadAsStringAsync().Result;
                    var resultado = JsonConvert.DeserializeObject<DTOObservacion>(datos);
                    return Json(resultado);
                }
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirmar([FromBody] DTOObservacion dto)
        {
            if (dto == null) return BadRequest();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.PostAsJsonAsync(urlObservacion + "/confirmar", dto);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return Ok();
                }
                string msg = respuesta.Content.ReadAsStringAsync().Result;
                return StatusCode((int)respuesta.StatusCode, msg);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: ObservacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ObservacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ObservacionController/Edit/5
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

        // GET: ObservacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ObservacionController/Delete/5
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
    }
}
