using DTOs.DTOEquipos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.Controllers
{
    public class EquipoController  : Controller
    {
        private string url = "";
        public EquipoController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "Equipo";
        }

        //----------------------------Listar equipo para dar de baja y editarlos

        public ActionResult Index()
        {
            IEnumerable<DTOEquipo> equiposDTO = new List<DTOEquipo>();
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
                    equiposDTO = JsonConvert.DeserializeObject<IEnumerable<DTOEquipo>>(resultado);
                }

            }
            catch (Exception ex) { }
            return View(equiposDTO);
        }
        public IActionResult CreateCamara()
        {
            DTOCamara dtoCamara = new DTOCamara();
            try
            {

                dtoCamara.Sensores = dtoCamara.Sensores;
            }
            catch (Exception ex) { }
            return View(dtoCamara);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult CreateCamara(DTOCamara dtoCamara)
        {
            try
            {

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> datosAEnviar = client.PostAsJsonAsync(url, dtoCamara);
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
            return View(dtoCamara);

        }
        //----------------------------------------------Telescpio
        public IActionResult CreateTelescopio()
        {
            DTOTelescopio dtoTelescopio = new DTOTelescopio();
            try
            {

                
            }
            catch (Exception ex) { }
            return View(dtoTelescopio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTelescopio(DTOTelescopio dtoTelescopio)
        {
            try
            {

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> datosAEnviar = client.PostAsJsonAsync(url, dtoTelescopio);
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
            return View(dtoTelescopio);

        }
        //----------------------------------------------montura
        public IActionResult CreateMontura()
        {
            DTOMontura dtoMontura = new DTOMontura();
            try
            {
                dtoMontura.TipoMonturas = null;

            }
            catch (Exception ex) { }
            return View(dtoMontura);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMontura(DTOMontura dtoMontura)
        {
            try
            {

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> datosAEnviar = client.PostAsJsonAsync(url, dtoMontura);
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
            return View(dtoMontura);

        }
        //--------------------------ocular
        public IActionResult CreateOcular()
        {
            DTOOcular dtoOcular = new DTOOcular();
            try
            {


            }
            catch (Exception ex) { }
            return View(dtoOcular);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOcular(DTOOcular dtoOcular)
        {
            try
            {

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> datosAEnviar = client.PostAsJsonAsync(url, dtoOcular);
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
            return View(dtoOcular);

        }

       
        
        
        //-----------------------------------------DELETE
        public ActionResult Delete(int id)
        {
            DTOEquipo dtoEquipo = new DTOEquipo();
            try 
            {
                DTOEquipo dtoE = 
                ViewBag.Id = id;
                
            }
            catch(Exception ex) 
            {
                ViewBag.Error = "Error en los datos";
            }
            return View(dtoEquipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DTOEquipo dtoEquipo)
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
 

        //------------------------------------------------------------ Edit
        public ActionResult Edit(int id)
        {
            DTOEquipo dtoEquipo = new DTOEquipo();
            try
            {
                DTOEquipo equipoDTO = 
                ViewBag.Id = id;
                //return View(equipoDTO);
            }
            
            catch( Exception ex)
            {
                ViewBag.Error = "Error en los datos";
            }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DTOEquipo dtoEquipo)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }catch
            {
                return View();
            }
        }

        //------------------------------------------------------------------- GET: Equipoes/Exists/5
       

        private bool EquipoExists(int id)
        {
            return true;
        }

        public ActionResult Details(int id)
        {
            DTOEquipo dtoEquipo = new DTOEquipo();
            try
            {
                DTOEquipo dtoListadoPais = new DTOEquipo();
                dtoEquipo.Id = dtoListadoPais.Id;
                dtoEquipo.Marca = dtoListadoPais.Marca;
                dtoEquipo.Modelo = dtoListadoPais.Modelo;
                dtoEquipo.Stock = dtoListadoPais.Stock;
                dtoEquipo.TipoEquipo = dtoListadoPais.TipoEquipo;
               
                ViewBag.Id = id;

            }

            catch (Exception ex)
            {
                ViewBag.Error = "Error en los datos";
            }

            return View(dtoEquipo);
        }
    }
}
    
