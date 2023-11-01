using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramación.Data;
using ProyectoProgramación.Models;

namespace ProyectoProgramación.Controllers
{
    public class MascotasController : Controller
    {
        private readonly ProyectoProgramaciónContext _context;

        public MascotasController(ProyectoProgramaciónContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
              return _context.Mascotas != null ? 
                          View(await _context.Mascotas.ToListAsync()) :
                          Problem("Entity set 'ProyectoProgramaciónContext.Mascotas'  is null.");
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mascotas == null)
            {
                return NotFound();
            }

            var mascotas = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotas == null)
            {
                return NotFound();
            }

            return View(mascotas);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Especie,Raza,FechaNacimiento,Genero,Observaciones")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascotas);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mascotas == null)
            {
                return NotFound();
            }

            var mascotas = await _context.Mascotas.FindAsync(id);
            if (mascotas == null)
            {
                return NotFound();
            }
            return View(mascotas);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Especie,Raza,FechaNacimiento,Genero,Observaciones")] Mascotas mascotas)
        {
            if (id != mascotas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotasExists(mascotas.Id))
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
            return View(mascotas);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mascotas == null)
            {
                return NotFound();
            }

            var mascotas = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotas == null)
            {
                return NotFound();
            }

            return View(mascotas);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mascotas == null)
            {
                return Problem("Entity set 'ProyectoProgramaciónContext.Mascotas'  is null.");
            }
            var mascotas = await _context.Mascotas.FindAsync(id);
            if (mascotas != null)
            {
                _context.Mascotas.Remove(mascotas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotasExists(int id)
        {
          return (_context.Mascotas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
