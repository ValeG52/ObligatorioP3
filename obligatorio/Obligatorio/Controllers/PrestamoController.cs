using CasosDeUso.DTOs.DTOPrestamos;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using ExcepcionesPropias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PrestamoController : Controller
    {
        public ICUListadoCamara CUListadoCamara { get; set; }
        public ICUListadoTelescopio CUListadoTelescopio { get; set; }
        public ICUListadoOcular CUListadoOcular { get; set; }
        public ICUListadoMontura CUListadoMontura { get; set; }
        public ICUAltaPrestamo CUAltaPrestamo { get; set; }

        public PrestamoController (ICUAltaPrestamo cuAltaPrestamo, ICUListadoCamara cuListadoCamara, ICUListadoMontura cuListadoMontura, ICUListadoOcular cuListadoOcular, ICUListadoTelescopio cuListadoTelescopio)
        {
            CUAltaPrestamo = cuAltaPrestamo;
            CUListadoCamara = cuListadoCamara;
            CUListadoMontura = cuListadoMontura;
            CUListadoOcular = cuListadoOcular;
            CUListadoTelescopio = cuListadoTelescopio;

        } 
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            DTOPrestamo dtoPrestamo = new DTOPrestamo();
            try
            {
                dtoPrestamo.Camaras = CUListadoCamara.Ejecutar();
                dtoPrestamo.Telescopios = CUListadoTelescopio.Ejecutar();
                dtoPrestamo.Oculares = CUListadoOcular.Ejecutar();
                dtoPrestamo.Monturas = CUListadoMontura.Ejecutar();
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
                CUAltaPrestamo.Ejecutar(dtoPrestamo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
            }
            dtoPrestamo.Camaras = CUListadoCamara.Ejecutar();
            dtoPrestamo.Telescopios = CUListadoTelescopio.Ejecutar();
            dtoPrestamo.Oculares = CUListadoOcular.Ejecutar();
            dtoPrestamo.Monturas = CUListadoMontura.Ejecutar();

            return View(dtoPrestamo);
        }
        
    }
}
