using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    public class AsiganacionViajesController : Controller
    {
        private readonly TestBusContext _context;

        public AsiganacionViajesController(TestBusContext context)
        {
            _context = context;
        }

        // GET: AsiganacionViajes
        public async Task<IActionResult> Index()
        {
            var testBusContext = _context.AsiganacionViajes.Include(a => a.IdBusNavigation).Include(a => a.IdEmpleadoNavigation).Include(a => a.IdHorarioNavigation).Include(a => a.IdRutaNavigation).Include(a => a.Usuario);
            return View(await testBusContext.ToListAsync());
        }

        // GET: AsiganacionViajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asiganacionViaje = await _context.AsiganacionViajes
                .Include(a => a.IdBusNavigation)
                .Include(a => a.IdEmpleadoNavigation)
                .Include(a => a.IdHorarioNavigation)
                .Include(a => a.IdRutaNavigation)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.IdAsiganacion == id);
            if (asiganacionViaje == null)
            {
                return NotFound();
            }

            return View(asiganacionViaje);
        }

        // GET: AsiganacionViajes/Create
        public IActionResult Create()
        {
            ViewData["IdBus"] = new SelectList(_context.Buses, "IdBus", "IdBus");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario");
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: AsiganacionViajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsiganacion,DescripcionRuta,Fecha,IdEmpleado,IdRuta,IdBus,IdHorario,AsientosOcupados,AsientosDisponibles,UsuarioId")] AsiganacionViaje asiganacionViaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asiganacionViaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBus"] = new SelectList(_context.Buses, "IdBus", "IdBus", asiganacionViaje.IdBus);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", asiganacionViaje.IdEmpleado);
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario", asiganacionViaje.IdHorario);
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta", asiganacionViaje.IdRuta);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", asiganacionViaje.UsuarioId);
            return View(asiganacionViaje);
        }

        // GET: AsiganacionViajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asiganacionViaje = await _context.AsiganacionViajes.FindAsync(id);
            if (asiganacionViaje == null)
            {
                return NotFound();
            }
            ViewData["IdBus"] = new SelectList(_context.Buses, "IdBus", "IdBus", asiganacionViaje.IdBus);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", asiganacionViaje.IdEmpleado);
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario", asiganacionViaje.IdHorario);
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta", asiganacionViaje.IdRuta);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", asiganacionViaje.UsuarioId);
            return View(asiganacionViaje);
        }

        // POST: AsiganacionViajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsiganacion,DescripcionRuta,Fecha,IdEmpleado,IdRuta,IdBus,IdHorario,AsientosOcupados,AsientosDisponibles,UsuarioId")] AsiganacionViaje asiganacionViaje)
        {
            if (id != asiganacionViaje.IdAsiganacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asiganacionViaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsiganacionViajeExists(asiganacionViaje.IdAsiganacion))
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
            ViewData["IdBus"] = new SelectList(_context.Buses, "IdBus", "IdBus", asiganacionViaje.IdBus);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", asiganacionViaje.IdEmpleado);
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario", asiganacionViaje.IdHorario);
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "IdRuta", "IdRuta", asiganacionViaje.IdRuta);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", asiganacionViaje.UsuarioId);
            return View(asiganacionViaje);
        }

        // GET: AsiganacionViajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asiganacionViaje = await _context.AsiganacionViajes
                .Include(a => a.IdBusNavigation)
                .Include(a => a.IdEmpleadoNavigation)
                .Include(a => a.IdHorarioNavigation)
                .Include(a => a.IdRutaNavigation)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.IdAsiganacion == id);
            if (asiganacionViaje == null)
            {
                return NotFound();
            }

            return View(asiganacionViaje);
        }

        // POST: AsiganacionViajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asiganacionViaje = await _context.AsiganacionViajes.FindAsync(id);
            if (asiganacionViaje != null)
            {
                _context.AsiganacionViajes.Remove(asiganacionViaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsiganacionViajeExists(int id)
        {
            return _context.AsiganacionViajes.Any(e => e.IdAsiganacion == id);
        }
    }
}
