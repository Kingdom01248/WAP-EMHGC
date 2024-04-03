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
    public class ForecastsController : Controller
    {
        private readonly WapEmhgcContext _context;

        public ForecastsController(WapEmhgcContext context)
        {
            _context = context;
        }

        // GET: Forecasts
        public async Task<IActionResult> Index()
        {
            var wapEmhgcContext = _context.Forecasts.Include(f => f.Data);
            return View(await wapEmhgcContext.ToListAsync());
        }

        // GET: Forecasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Forecasts == null)
            {
                return NotFound();
            }

            var forecast = await _context.Forecasts
                .Include(f => f.Data)
                .FirstOrDefaultAsync(m => m.ForecastId == id);
            if (forecast == null)
            {
                return NotFound();
            }

            return View(forecast);
        }

        // GET: Forecasts/Create
        public IActionResult Create()
        {
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId");
            return View();
        }

        // POST: Forecasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForecastId,Name,ForecastAsia,ForecastEnso,ForecastTemp,ForecastWind,ForecastSea,Note,Status,DataId")] Forecast forecast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forecast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", forecast.DataId);
            return View(forecast);
        }

        // GET: Forecasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Forecasts == null)
            {
                return NotFound();
            }

            var forecast = await _context.Forecasts.FindAsync(id);
            if (forecast == null)
            {
                return NotFound();
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", forecast.DataId);
            return View(forecast);
        }

        // POST: Forecasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ForecastId,Name,ForecastAsia,ForecastEnso,ForecastTemp,ForecastWind,ForecastSea,Note,Status,DataId")] Forecast forecast)
        {
            if (id != forecast.ForecastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forecast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForecastExists(forecast.ForecastId))
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
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", forecast.DataId);
            return View(forecast);
        }

        // GET: Forecasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Forecasts == null)
            {
                return NotFound();
            }

            var forecast = await _context.Forecasts
                .Include(f => f.Data)
                .FirstOrDefaultAsync(m => m.ForecastId == id);
            if (forecast == null)
            {
                return NotFound();
            }

            return View(forecast);
        }

        // POST: Forecasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Forecasts == null)
            {
                return Problem("Entity set 'WapEmhgcContext.Forecasts'  is null.");
            }
            var forecast = await _context.Forecasts.FindAsync(id);
            if (forecast != null)
            {
                _context.Forecasts.Remove(forecast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForecastExists(int id)
        {
          return (_context.Forecasts?.Any(e => e.ForecastId == id)).GetValueOrDefault();
        }
    }
}
