using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebIClips.Models;

namespace WebIClips.Controllers
{
    public class PracasController : Controller
    {
        private readonly IClipsDesafioContext _context;

        public PracasController(IClipsDesafioContext context)
        {
            _context = context;
        }

        // GET: Pracas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pracas.ToListAsync());
        }

   

        // GET: Pracas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracas = await _context.Pracas
                .FirstOrDefaultAsync(m => m.IdPraca == id);
            if (pracas == null)
            {
                return NotFound();
            }

            return View(pracas);
        }

        // GET: Pracas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pracas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPraca,Praca,Sigla,Estado")] Pracas pracas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pracas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pracas);
        }

        // GET: Pracas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracas = await _context.Pracas.FindAsync(id);
            if (pracas == null)
            {
                return NotFound();
            }
            return View(pracas);
        }

        // POST: Pracas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPraca,Praca,Sigla,Estado")] Pracas pracas)
        {
            if (id != pracas.IdPraca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pracas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracasExists(pracas.IdPraca))
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
            return View(pracas);
        }

        // GET: Pracas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracas = await _context.Pracas
                .FirstOrDefaultAsync(m => m.IdPraca == id);
            if (pracas == null)
            {
                return NotFound();
            }

            return View(pracas);
        }

        // POST: Pracas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pracas = await _context.Pracas.FindAsync(id);
            _context.Pracas.Remove(pracas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracasExists(int id)
        {
            return _context.Pracas.Any(e => e.IdPraca == id);
        }
    }
}
