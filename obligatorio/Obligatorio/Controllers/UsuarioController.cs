using CasosDeUso.DTOs.DTOUsuarios;
using CasosDeUso.InterfacesCasosDeUso;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using CasosDeUso.ManejoUsuarios;
using LogicaDeAplicacion.CasosDeUsoUsuario;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
       
            private ICULoginUsuario CULoginUsuario;
        private ICUAltaUsuario CUAltaUsuario;

        //el constructor del controlador recibe por inyeccion de dependencias el caso de uso que necesita para loguear al socio
        public UsuarioController(ICULoginUsuario cuLogin, ICUAltaUsuario cuAlta)
            {
               CUAltaUsuario = cuAlta;
               CULoginUsuario = cuLogin;
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
                    //ejecutamos la logica
                    DTOUsuario usuarioLogueado = CULoginUsuario.Ejecutar(email, password);

                    //si todo esta bien guardamos los datos en la sesion
                    HttpContext.Session.SetString("UsuarioEmail", usuarioLogueado.Email);
                    HttpContext.Session.SetString("UsuarioRol", usuarioLogueado.Rol.ToString());

                    //mandamos al usuario a la pagina principal
                    return RedirectToAction("Index", "Home");
                } catch (Exception ex)
                {
                    //si hubo un error mostramos el mensaje del error
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
                CUAltaUsuario.Ejecutar(dtoUsuario);
                return RedirectToAction(nameof(Login));
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
