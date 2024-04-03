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
    public class DataStationsController : Controller
    {
        private readonly WapEmhgcContext _context;

        public DataStationsController(WapEmhgcContext context)
        {
            _context = context;
        }

        // GET: DataStations
        public async Task<IActionResult> Index()
        {
            var wapEmhgcContext = _context.DataStations.Include(d => d.Data);
            return View(await wapEmhgcContext.ToListAsync());
        }

        // GET: DataStations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataStations == null)
            {
                return NotFound();
            }

            var dataStation = await _context.DataStations
                .Include(d => d.Data)
                .FirstOrDefaultAsync(m => m.DataStationId == id);
            if (dataStation == null)
            {
                return NotFound();
            }

            return View(dataStation);
        }

        // GET: DataStations/Create
        public IActionResult Create()
        {
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId");
            return View();
        }

        // POST: DataStations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataStationId,Name,LocationPlace,Station,DataId,Status")] DataStation dataStation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", dataStation.DataId);
            return View(dataStation);
        }

        // GET: DataStations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataStations == null)
            {
                return NotFound();
            }

            var dataStation = await _context.DataStations.FindAsync(id);
            if (dataStation == null)
            {
                return NotFound();
            }
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", dataStation.DataId);
            return View(dataStation);
        }

        // POST: DataStations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataStationId,Name,LocationPlace,Station,DataId,Status")] DataStation dataStation)
        {
            if (id != dataStation.DataStationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataStationExists(dataStation.DataStationId))
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
            ViewData["DataId"] = new SelectList(_context.Data, "DataId", "DataId", dataStation.DataId);
            return View(dataStation);
        }

        // GET: DataStations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataStations == null)
            {
                return NotFound();
            }

            var dataStation = await _context.DataStations
                .Include(d => d.Data)
                .FirstOrDefaultAsync(m => m.DataStationId == id);
            if (dataStation == null)
            {
                return NotFound();
            }

            return View(dataStation);
        }

        // POST: DataStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataStations == null)
            {
                return Problem("Entity set 'WapEmhgcContext.DataStations'  is null.");
            }
            var dataStation = await _context.DataStations.FindAsync(id);
            if (dataStation != null)
            {
                _context.DataStations.Remove(dataStation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataStationExists(int id)
        {
          return (_context.DataStations?.Any(e => e.DataStationId == id)).GetValueOrDefault();
        }
    }
}
