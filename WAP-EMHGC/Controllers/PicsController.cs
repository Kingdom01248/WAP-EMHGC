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
    public class PicsController : Controller
    {
        private readonly WapEmhgcContext _context;

        public PicsController(WapEmhgcContext context)
        {
            _context = context;
        }

        // GET: Pics
        public async Task<IActionResult> Index()
        {
            var wapEmhgcContext = _context.Pics.Include(p => p.News);
            return View(await wapEmhgcContext.ToListAsync());
        }

        // GET: Pics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pics == null)
            {
                return NotFound();
            }

            var pic = await _context.Pics
                .Include(p => p.News)
                .FirstOrDefaultAsync(m => m.PicId == id);
            if (pic == null)
            {
                return NotFound();
            }

            return View(pic);
        }

        // GET: Pics/Create
        public IActionResult Create()
        {
            ViewData["NewsId"] = new SelectList(_context.News, "NewsId", "NewsId");
            return View();
        }

        // POST: Pics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PicId,Img,Title,NewsId,Status")] Pic pic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsId"] = new SelectList(_context.News, "NewsId", "NewsId", pic.NewsId);
            return View(pic);
        }

        // GET: Pics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pics == null)
            {
                return NotFound();
            }

            var pic = await _context.Pics.FindAsync(id);
            if (pic == null)
            {
                return NotFound();
            }
            ViewData["NewsId"] = new SelectList(_context.News, "NewsId", "NewsId", pic.NewsId);
            return View(pic);
        }

        // POST: Pics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PicId,Img,Title,NewsId,Status")] Pic pic)
        {
            if (id != pic.PicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PicExists(pic.PicId))
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
            ViewData["NewsId"] = new SelectList(_context.News, "NewsId", "NewsId", pic.NewsId);
            return View(pic);
        }

        // GET: Pics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pics == null)
            {
                return NotFound();
            }

            var pic = await _context.Pics
                .Include(p => p.News)
                .FirstOrDefaultAsync(m => m.PicId == id);
            if (pic == null)
            {
                return NotFound();
            }

            return View(pic);
        }

        // POST: Pics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pics == null)
            {
                return Problem("Entity set 'WapEmhgcContext.Pics'  is null.");
            }
            var pic = await _context.Pics.FindAsync(id);
            if (pic != null)
            {
                _context.Pics.Remove(pic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PicExists(int id)
        {
          return (_context.Pics?.Any(e => e.PicId == id)).GetValueOrDefault();
        }
    }
}
