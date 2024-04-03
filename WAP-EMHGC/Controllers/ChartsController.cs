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
    public class ChartsController : Controller
    {
        private readonly WapEmhgcContext _context;

        public ChartsController(WapEmhgcContext context)
        {
            _context = context;
        }

        // GET: Charts
        public async Task<IActionResult> Index()
        {
            var wapEmhgcContext = _context.Charts.Include(c => c.Data);
            return View(await wapEmhgcContext.ToListAsync());
        }

        // GET: Charts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Charts == null)
            {
                return NotFound();
            }

            var chart = await _context.Charts
                .Include(c => c.Data)
                .FirstOrDefaultAsync(m => m.ChartId == id);
            if (chart == null)
            {
                return NotFound();
            }

            return View(chart);
        }

        // GET: Charts/Create
        public IActionResult Create()
        {
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId");
            return View();
        }

        // POST: Charts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChartId,Name,GraphVie,GraphJtwc,GraphObj,GraphTb,GraphWo,GraphOrther,DataId,Status")] Chart chart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", chart.DataId);
            return View(chart);
        }

        // GET: Charts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Charts == null)
            {
                return NotFound();
            }

            var chart = await _context.Charts.FindAsync(id);
            if (chart == null)
            {
                return NotFound();
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", chart.DataId);
            return View(chart);
        }

        // POST: Charts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChartId,Name,GraphVie,GraphJtwc,GraphObj,GraphTb,GraphWo,GraphOrther,DataId,Status")] Chart chart)
        {
            if (id != chart.ChartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChartExists(chart.ChartId))
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
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", chart.DataId);
            return View(chart);
        }

        // GET: Charts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Charts == null)
            {
                return NotFound();
            }

            var chart = await _context.Charts
                .Include(c => c.Data)
                .FirstOrDefaultAsync(m => m.ChartId == id);
            if (chart == null)
            {
                return NotFound();
            }

            return View(chart);
        }

        // POST: Charts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Charts == null)
            {
                return Problem("Entity set 'WapEmhgcContext.Charts'  is null.");
            }
            var chart = await _context.Charts.FindAsync(id);
            if (chart != null)
            {
                _context.Charts.Remove(chart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChartExists(int id)
        {
          return (_context.Charts?.Any(e => e.ChartId == id)).GetValueOrDefault();
        }
    }
}
