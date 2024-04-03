using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WAP_EMHGC.Models;

namespace WAP_EMHGC.Controllers
{
    public class AnliesController : Controller
    {
        private readonly WapEmhgcContext _context;

        public AnliesController(WapEmhgcContext context)
        {
            _context = context;
        }

        // GET: Anlies
        public async Task<IActionResult> Index()
        {
            var wapEmhgcContext = _context.Anlies.Include(a => a.Data);
            return View(await wapEmhgcContext.ToListAsync());
        }

        // GET: Anlies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anlies == null)
            {
                return NotFound();
            }

            var anly = await _context.Anlies
                .Include(a => a.Data)
                .FirstOrDefaultAsync(m => m.AnlyId == id);
            if (anly == null)
            {
                return NotFound();
            }

            return View(anly);
        }

        // GET: Anlies/Create
        public IActionResult Create()
        {
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId");
            return View();
        }

        // POST: Anlies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnlyId,Name,DataId,Status")] Anly anly)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", anly.DataId);
            return View(anly);
        }

        // GET: Anlies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anlies == null)
            {
                return NotFound();
            }

            var anly = await _context.Anlies.FindAsync(id);
            if (anly == null)
            {
                return NotFound();
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", anly.DataId);
            return View(anly);
        }

        // POST: Anlies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnlyId,Name,DataId,Status")] Anly anly)
        {
            if (id != anly.AnlyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnlyExists(anly.AnlyId))
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
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", anly.DataId);
            return View(anly);
        }

        // GET: Anlies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anlies == null)
            {
                return NotFound();
            }

            var anly = await _context.Anlies
                .Include(a => a.Data)
                .FirstOrDefaultAsync(m => m.AnlyId == id);
            if (anly == null)
            {
                return NotFound();
            }

            return View(anly);
        }

        // POST: Anlies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anlies == null)
            {
                return Problem("Entity set 'WapEmhgcContext.Anlies'  is null.");
            }
            var anly = await _context.Anlies.FindAsync(id);
            if (anly != null)
            {
                _context.Anlies.Remove(anly);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnlyExists(int id)
        {
          return (_context.Anlies?.Any(e => e.AnlyId == id)).GetValueOrDefault();
        }
    }
}
