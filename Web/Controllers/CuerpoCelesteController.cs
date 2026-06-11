using CasosDeUso.DTOs.DTOCuerpoCeleste;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class CuerpoCelesteController : Controller
    {
        private string urlObservacion = "";
        public CuerpoCelesteController(IConfiguration configuration)
        {
            var urlBase = configuration.GetValue<string>("urlBase");
            urlObservacion = urlBase + "Observacion";
        }

        public ActionResult Ranking()
        {
            IEnumerable<DTOListadoCuerpoCeleste> lista = new List<DTOListadoCuerpoCeleste>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlObservacion + "/ranking");
                tarea.Wait();
                HttpResponseMessage resp = tarea.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string datos = resp.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<IEnumerable<DTOListadoCuerpoCeleste>>(datos);
                }
            }
            catch { }

            return View(lista);
        }
    }
}
