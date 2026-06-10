using DTOs.DTOEquipos;
using DTOs.DTOUsuarios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private string url = "";
        public UsuarioController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "Usuario";
        }

        //muestra el formulario de login (GET

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
        public ActionResult Create()
        {
            return View();
        }

        //POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOUsuario dtoUsuario)
        { 
            try
            {

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> datosAEnviar = client.PostAsJsonAsync(url, dtoUsuario);
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
            return View();
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
