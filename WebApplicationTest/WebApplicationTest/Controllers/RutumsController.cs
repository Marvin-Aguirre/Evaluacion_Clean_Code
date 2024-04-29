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
    public class RutumsController : Controller
    {
        private readonly TestBusContext _context;

        public RutumsController(TestBusContext context)
        {
            _context = context;
        }

        // GET: Rutas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ruta.ToListAsync());
        }

        // GET: Rutas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutum = await _context.Ruta
                .FirstOrDefaultAsync(m => m.IdRuta == id);
            if (rutum == null)
            {
                return NotFound();
            }

            return View(rutum);
        }

        // GET: Rutas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRuta,Origen,Destino")] Rutum rutum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rutum);
        }

        // GET: Rutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutum = await _context.Ruta.FindAsync(id);
            if (rutum == null)
            {
                return NotFound();
            }
            return View(rutum);
        }

        // POST: Rutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRuta,Origen,Destino")] Rutum rutum)
        {
            if (id != rutum.IdRuta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutumExists(rutum.IdRuta))
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
            return View(rutum);
        }

        // GET: Rutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutum = await _context.Ruta
                .FirstOrDefaultAsync(m => m.IdRuta == id);
            if (rutum == null)
            {
                return NotFound();
            }

            return View(rutum);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rutum = await _context.Ruta.FindAsync(id);
            if (rutum != null)
            {
                _context.Ruta.Remove(rutum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutumExists(int id)
        {
            return _context.Ruta.Any(e => e.IdRuta == id);
        }
    }
}
