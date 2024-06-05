using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiProjetoFinal.Models;

namespace ApiProjetoFinal.Controllers
{
    public class ObjetoController : Controller
    {
        private readonly Contexto _context;

        public ObjetoController(Contexto context)
        {
            _context = context;
        }

        // GET: Objeto
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Objeto.Include(o => o.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Objeto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Objeto == null)
            {
                return NotFound();
            }

            var objeto = await _context.Objeto
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objeto == null)
            {
                return NotFound();
            }

            return View(objeto);
        }

        // GET: Objeto/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioNome");
            return View();
        }

        // POST: Objeto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObjetoNome,ObjetoCor,ObjetoObservacao,ObjetoLocalDesaparecimento,ObjetoFoto,ObjetoDtDesaparecimento,ObjetoDtEncontro,ObjetoStatus,UsuarioId")] Objeto objeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", objeto.UsuarioId);
            return View(objeto);
        }

        // GET: Objeto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Objeto == null)
            {
                return NotFound();
            }

            var objeto = await _context.Objeto.FindAsync(id);
            if (objeto == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", objeto.UsuarioId);
            return View(objeto);
        }

        // POST: Objeto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ObjetoNome,ObjetoCor,ObjetoObservacao,ObjetoLocalDesaparecimento,ObjetoFoto,ObjetoDtDesaparecimento,ObjetoDtEncontro,ObjetoStatus,UsuarioId")] Objeto objeto)
        {
            if (id != objeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetoExists(objeto.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", objeto.UsuarioId);
            return View(objeto);
        }

        // GET: Objeto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Objeto == null)
            {
                return NotFound();
            }

            var objeto = await _context.Objeto
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objeto == null)
            {
                return NotFound();
            }

            return View(objeto);
        }

        // POST: Objeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Objeto == null)
            {
                return Problem("Entity set 'Contexto.Objeto'  is null.");
            }
            var objeto = await _context.Objeto.FindAsync(id);
            if (objeto != null)
            {
                _context.Objeto.Remove(objeto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetoExists(int id)
        {
          return (_context.Objeto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
