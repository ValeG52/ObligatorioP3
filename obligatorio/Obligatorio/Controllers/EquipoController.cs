using CasosDeUso.DTOs.DTOEquipos;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using LogicaAccesoDatos;
using LogicaAplicacion.CasosDeUsoEnum;
using LogicaAplicacion.CasosDeUsoEquipo;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcepcionesPropias;

namespace Web.Controllers
{
    public class EquipoController : Controller
    {
        public AppContexto Contexto { get; set; }
        public ICUAltaCamara CUAltaCamara { get; set; }
        public ICUListadoSensor CUListadoSensores { get; set; }
        public ICUAltaTelescopio CUAltaTelescopio { get; set; }
        public ICUListadoTipoMontura CUListadoTipoMontura { get; set; }
        public ICUAltaMontura CUAltaMontura { get; set; }
        public ICUAltaOcular CUAltaOcular { get; set; }
        public ICUListadoEquipo CUListadoEquipo { get; set; }
        public ICUDeleteEquipo CUDeleteEquipo { get; set; }
        public ICUBuscarEquipo CUBuscarEquipo { get; set; }
        public EquipoController(ICUAltaCamara cuAltaCamara, ICUListadoSensor cuListadoSensores, ICUAltaTelescopio cUAltaTelescopio, ICUListadoTipoMontura cUListadoTipoMontura, ICUAltaMontura cUAltaMontura, ICUAltaOcular cUAltaOcular, ICUListadoEquipo cUListadoEquipo, ICUDeleteEquipo cuDeleteEquipo, ICUBuscarEquipo cUBuscarEquipo)
        {
            CUAltaCamara = cuAltaCamara;
            CUListadoSensores = cuListadoSensores;
            CUAltaTelescopio = cUAltaTelescopio;
            CUListadoTipoMontura = cUListadoTipoMontura;
            CUAltaMontura = cUAltaMontura;
            CUAltaOcular = cUAltaOcular;
            CUListadoEquipo = cUListadoEquipo;
            CUDeleteEquipo = cuDeleteEquipo;
            CUBuscarEquipo = cUBuscarEquipo;
        }


        public IActionResult CreateCamara()
        {
            DTOCamara dtoCamara = new DTOCamara();
            try
            {

                dtoCamara.Sensores = CUListadoSensores.Ejecutar();
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
                CUAltaCamara.Ejecutar(dtoCamara);
                return RedirectToAction(nameof(Index));
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
                CUAltaTelescopio.Ejecutar(dtoTelescopio);
                return RedirectToAction(nameof(Index));
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
                dtoMontura.TipoMonturas = CUListadoTipoMontura.Ejecutar();


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
                CUAltaMontura.Ejecutar(dtoMontura);
                return RedirectToAction(nameof(Index));
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
                CUAltaOcular.Ejecutar(dtoOcular);
                return RedirectToAction(nameof(Index));
            }
            catch
            {


            }
            return View(dtoOcular);

        }

        //----------------------------Listar equipo para dar de baja y editarlos

        public ActionResult Index()
        {
            IEnumerable<DTOEquipo> equiposDTO = new List<DTOEquipo>();
            try
            {
                equiposDTO = CUListadoEquipo.Ejecutar();

            }
            catch (Exception ex) { }
            return View(equiposDTO);
        }
        
        
        //-----------------------------------------DELETE
        public ActionResult Delete(int id)
        {
            DTOEquipo dtoEquipo = new DTOEquipo();
            try 
            {
                DTOEquipo dtoE = CUBuscarEquipo.Ejecutar(id);
                ViewBag.Id = id;
                
            }catch(DatosInvalidosException ex)
            {
                ViewBag.Error = ex.Message;
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
                CUDeleteEquipo.Ejecutar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
 

        //------------------------------------------------------------ GET: Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await Contexto.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Stock,Estado")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Contexto.Update(equipo);
                    await Contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //------------------------------------------------------------------- GET: Equipoes/Exists/5
       

        private bool EquipoExists(int id)
        {
            return Contexto.Equipos.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await Contexto.Equipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }
    }
}
    
