using CasosDeUso.DTOs.DTOAuditoria;
using CasosDeUso.DTOs.DTOUsuarios;
using DTOs.DTOPrestamos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    // Nota: restringir con [Authorize(Roles = "Administrador")] si se configura autenticación
    public class AuditoriaController : Controller
    {
        private string urlAuditoria = "";
        private string urlUsuario = "";

        public AuditoriaController(IConfiguration configuration)
        {
            var urlBase = configuration.GetValue<string>("urlBase");
            urlAuditoria = urlBase + "Auditoria";
            urlUsuario = urlBase + "Usuario";
        }

        public ActionResult Index()
        {
            // cargar coordinadores
            IEnumerable<DTOCoordinador> coords = new List<DTOCoordinador>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlAuditoria + "/coordinadores");
                tarea.Wait();
                HttpResponseMessage resp = tarea.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string datos = resp.Content.ReadAsStringAsync().Result;
                    coords = JsonConvert.DeserializeObject<IEnumerable<DTOCoordinador>>(datos);
                }
            }
            catch { }

            ViewBag.Coordinadores = coords;
            return View();
        }

        [HttpGet]
        public ActionResult PrestamosPorCoordinador(int idCoordinador)
        {
            IEnumerable<DTOListadoPrestamo> prestamos = new List<DTOListadoPrestamo>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlAuditoria + $"/prestamosPorCoordinador/{idCoordinador}");
                tarea.Wait();
                HttpResponseMessage resp = tarea.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string datos = resp.Content.ReadAsStringAsync().Result;
                    prestamos = JsonConvert.DeserializeObject<IEnumerable<DTOListadoPrestamo>>(datos);
                }
            }
            catch { }

            return PartialView("_PrestamosTable", prestamos);
        }

        [HttpGet]
        public ActionResult AuditoriasPorPrestamo(int idPrestamo)
        {
            IEnumerable<DTOAuditoria> auditorias = new List<DTOAuditoria>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlAuditoria + $"/auditoriasPorPrestamo/{idPrestamo}");
                tarea.Wait();
                HttpResponseMessage resp = tarea.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string datos = resp.Content.ReadAsStringAsync().Result;
                    auditorias = JsonConvert.DeserializeObject<IEnumerable<DTOAuditoria>>(datos);
                }
            }
            catch { }

            return PartialView("_AuditoriasTable", auditorias);
        }

        public ActionResult Details(int idPrestamo)
        {
            // show auditorias por prestamo en vista completa
            IEnumerable<DTOAuditoria> auditorias = new List<DTOAuditoria>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlAuditoria + $"/auditoriasPorPrestamo/{idPrestamo}");
                tarea.Wait();
                HttpResponseMessage resp = tarea.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string datos = resp.Content.ReadAsStringAsync().Result;
                    auditorias = JsonConvert.DeserializeObject<IEnumerable<DTOAuditoria>>(datos);
                }
            }
            catch { }

            ViewBag.PrestamoId = idPrestamo;
            return View(auditorias);
        }
    }
}
