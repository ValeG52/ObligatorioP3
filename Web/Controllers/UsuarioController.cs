using DTOs.DTOEquipos;
using DTOs.DTOUsuarios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private string url = "";
        public UsuarioController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "Usuario";
        }

        // GET: Usuario/SociosPorTelescopio
        public ActionResult SociosPorTelescopio()
        {
            // cargar lista de telescopios desde Equipo API
            string urlEquipo = HttpContext.RequestServices.GetService(typeof(IConfiguration)) is IConfiguration conf ? conf.GetValue<string>("urlBase") + "Equipo" : "";
            IEnumerable<DTOs.DTOEquipos.DTOListadoTelescopio> telescopios = new List<DTOs.DTOEquipos.DTOListadoTelescopio>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(urlEquipo + "/listadoTelescopios");
                tarea.Wait();
                HttpResponseMessage resp = tarea.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string datos = resp.Content.ReadAsStringAsync().Result;
                    telescopios = JsonConvert.DeserializeObject<IEnumerable<DTOs.DTOEquipos.DTOListadoTelescopio>>(datos);
                }
            }
            catch { }

            ViewBag.Telescopios = telescopios;
            return View(new List<DTOListadoUsuario>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SociosPorTelescopio(int idTelescopio)
        {
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(url + $"/listadoSociosPorTelescopio/{idTelescopio}");
                tarea.Wait();
                HttpResponseMessage resp = tarea.Result;
                IEnumerable<DTOListadoUsuario> socios = new List<DTOListadoUsuario>();
                if (resp.IsSuccessStatusCode)
                {
                    string datos = resp.Content.ReadAsStringAsync().Result;
                    socios = JsonConvert.DeserializeObject<IEnumerable<DTOListadoUsuario>>(datos);
                }

                // cargar telescopios para volver a mostrar el select
                string urlEquipo = HttpContext.RequestServices.GetService(typeof(IConfiguration)) is IConfiguration conf ? conf.GetValue<string>("urlBase") + "Equipo" : "";
                HttpClient client2 = new HttpClient();
                Task<HttpResponseMessage> tarea2 = client2.GetAsync(urlEquipo + "/listadoTelescopios");
                tarea2.Wait();
                HttpResponseMessage resp2 = tarea2.Result;
                if (resp2.IsSuccessStatusCode)
                {
                    string datos = resp2.Content.ReadAsStringAsync().Result;
                    ViewBag.Telescopios = JsonConvert.DeserializeObject<IEnumerable<DTOs.DTOEquipos.DTOListadoTelescopio>>(datos);
                }

                return View(socios);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<DTOListadoUsuario>());
            }
        }
        
        
        
        //-------------------------------------------LISTADO USUARIOS--------------------------------------
        public ActionResult Index()
        {
            IEnumerable<DTOListadoUsuario> usuarios = new List<DTOListadoUsuario>();
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> tarea = client.GetAsync(url + "/listadoUsuarios");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> datos = contenido.ReadAsStringAsync();
                    datos.Wait();
                    string resultado = datos.Result;
                    usuarios = JsonConvert.DeserializeObject<IEnumerable<DTOListadoUsuario>>(resultado);
                }

            }
            catch (Exception ex) { }
            return View(usuarios);
        }




        //-----------------------------------------------LOGIN--------------------------------------

        public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Login(string email, string password)
            {
                try
                {

                DTOUsuario usuarioLogueado = null;

                   
                    //HttpContext.Session.SetString("UsuarioEmail", usuarioLogueado.Email);
                    //HttpContext.Session.SetString("UsuarioRol", usuarioLogueado.Rol.ToString());

                    
                    return RedirectToAction("Index", "Home");
                } catch (Exception ex)
                {
                    
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }


        //--------------------------------------ALTA USUARIOS--------------------------------------
        public ActionResult Create()
        {
            DTOUsuario dtoUsuario = new DTOUsuario();

            try
            {

                CargarRoles(dtoUsuario);
                return View(dtoUsuario);


            }
            catch (Exception ex)
            {

            }
            return View(dtoUsuario);
        }


        //POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOUsuario dtoUsuario)
        { 
            try
            {

                HttpClient client = new HttpClient();

                Task<HttpResponseMessage> tarea = client.PostAsJsonAsync(url + "/createUsuario", dtoUsuario);
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
                    CargarRoles(dtoUsuario);
                    return View(dtoUsuario);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                CargarRoles(dtoUsuario);
                return View(dtoUsuario);
            }

            
        }
        private void CargarRoles(DTOUsuario dtoUsuario)
        {
            HttpClient client = new HttpClient();

            Task<HttpResponseMessage> tarea = client.GetAsync(url + "/roles");
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;
                Task<string> datosRespuesta = contenido.ReadAsStringAsync();
                datosRespuesta.Wait();
                string datos = datosRespuesta.Result;
                dtoUsuario.Roles = JsonConvert.DeserializeObject<List<string>>(datos);


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







        //para cerrar sesion
        public IActionResult Logout()
            {
                //limpiamos la sesion
                HttpContext.Session.Clear();

                //mandamos al usuario a la pagina de login
                return RedirectToAction("Login");
            }
        }
    }
