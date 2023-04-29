using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020CC605.Models;

namespace P2_2020CC605.Controllers
{
    public class departamentosController : Controller
    {
        private readonly covidDBContext _context;

        public departamentosController(covidDBContext context)
        {
            _context = context;
        }

        // GET: departamentos
        public async Task<IActionResult> Index()
        {
              return _context.departamentos != null ? 
                          View(await _context.departamentos.ToListAsync()) :
                          Problem("Entity set 'covidDBContext.departamentos'  is null.");
        }

        // GET: departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departamentos == null)
            {
                return NotFound();
            }

            var departamentos = await _context.departamentos
                .FirstOrDefaultAsync(m => m.id_departamento == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // GET: departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_departamento,departamento")] departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentos);
        }

        // GET: departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.departamentos == null)
            {
                return NotFound();
            }

            var departamentos = await _context.departamentos.FindAsync(id);
            if (departamentos == null)
            {
                return NotFound();
            }
            return View(departamentos);
        }

        // POST: departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_departamento,departamento")] departamentos departamentos)
        {
            if (id != departamentos.id_departamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departamentosExists(departamentos.id_departamento))
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
            return View(departamentos);
        }

        // GET: departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departamentos == null)
            {
                return NotFound();
            }

            var departamentos = await _context.departamentos
                .FirstOrDefaultAsync(m => m.id_departamento == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // POST: departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departamentos == null)
            {
                return Problem("Entity set 'covidDBContext.departamentos'  is null.");
            }
            var departamentos = await _context.departamentos.FindAsync(id);
            if (departamentos != null)
            {
                _context.departamentos.Remove(departamentos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departamentosExists(int id)
        {
          return (_context.departamentos?.Any(e => e.id_departamento == id)).GetValueOrDefault();
        }
    }
}
