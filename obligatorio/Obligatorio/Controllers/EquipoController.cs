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


namespace Web.Controllers
{
    public class EquipoController : Controller
    {
        public AppContexto Contexto { get; set; }
        public ICUAltaCamara CUAltaCamara { get; set; }
        public ICUListadoSensor CUListadoSensores { get; set; }
        public ICUListadoEstado CUListadoEstado { get; set; }

        public EquipoController(ICUAltaCamara cuAltaCamara, ICUListadoSensor cuListadoSensores, ICUListadoEstado cuListadoEstado)
        {
            CUAltaCamara = cuAltaCamara;
            CUListadoSensores = cuListadoSensores;
            CUListadoEstado = cuListadoEstado;
        }


        public IActionResult CreateCamara()
        {
            DTOCamara dtoCamara = new DTOCamara();
            try
            {
                dtoCamara.Estados = CUListadoEstado.Ejecutar();

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

        // GET: Equipoes/Edit/5
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

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await Contexto.Equipos.FindAsync(id);
            if (equipo != null)
            {
                Contexto.Equipos.Remove(equipo);
            }

            await Contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

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
    
