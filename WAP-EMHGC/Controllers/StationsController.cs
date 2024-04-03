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
    public class StationsController : Controller
    {
        private readonly WapEmhgcContext _context;

        public StationsController(WapEmhgcContext context)
        {
            _context = context;
        }

        // GET: Stations
        public async Task<IActionResult> Index()
        {
            var wapEmhgcContext = _context.Stations.Include(s => s.DataStation);
            return View(await wapEmhgcContext.ToListAsync());
        }

        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stations == null)
            {
                return NotFound();
            }

            var station = await _context.Stations
                .Include(s => s.DataStation)
                .FirstOrDefaultAsync(m => m.StationId == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            ViewData["DataStationId"] = new SelectList(_context.DataStations, "DataStationId", "DataStationId");
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StationId,Idstation,Name,TempMin,Tempmax,NorTemp,Feedlike,WindMax,GustWind,Pressuse,Hummity,Lat,Lon,Wave,HighSufw,LowSufw,Rain,RainPossi,DewPoint,Cloud,Snow,TimeUpdate,Note,DataStationId,Status")] Station station)
        {
            if (ModelState.IsValid)
            {
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DataStationId"] = new SelectList(_context.DataStations, "DataStationId", "DataStationId", station.DataStationId);
            return View(station);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stations == null)
            {
                return NotFound();
            }

            var station = await _context.Stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }
            ViewData["DataStationId"] = new SelectList(_context.DataStations, "DataStationId", "DataStationId", station.DataStationId);
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StationId,Idstation,Name,TempMin,Tempmax,NorTemp,Feedlike,WindMax,GustWind,Pressuse,Hummity,Lat,Lon,Wave,HighSufw,LowSufw,Rain,RainPossi,DewPoint,Cloud,Snow,TimeUpdate,Note,DataStationId,Status")] Station station)
        {
            if (id != station.StationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(station);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.StationId))
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
            ViewData["DataStationId"] = new SelectList(_context.DataStations, "DataStationId", "DataStationId", station.DataStationId);
            return View(station);
        }

        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stations == null)
            {
                return NotFound();
            }

            var station = await _context.Stations
                .Include(s => s.DataStation)
                .FirstOrDefaultAsync(m => m.StationId == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stations == null)
            {
                return Problem("Entity set 'WapEmhgcContext.Stations'  is null.");
            }
            var station = await _context.Stations.FindAsync(id);
            if (station != null)
            {
                _context.Stations.Remove(station);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(int id)
        {
          return (_context.Stations?.Any(e => e.StationId == id)).GetValueOrDefault();
        }
    }
}
