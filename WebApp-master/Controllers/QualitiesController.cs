using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Database.Context;
using WebApp.Model;

namespace WebApp.Controllers
{
    public class QualitiesController : Controller
    {
        private readonly MainContex _context;

        public QualitiesController(MainContex context)
        {
            _context = context;
        }

        // GET: Qualities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Qualities.ToListAsync());
        }

        // GET: Qualities/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quality = await _context.Qualities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quality == null)
            {
                return NotFound();
            }

            return View(quality);
        }

        // GET: Qualities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qualities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Smile,Beauty,Nature,Character,Communication,Humor,OfPersonId,ByPersonId")] Quality quality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quality);
        }

        // GET: Qualities/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quality = await _context.Qualities.FindAsync(id);
            if (quality == null)
            {
                return NotFound();
            }
            return View(quality);
        }

        // POST: Qualities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Smile,Beauty,Nature,Character,Communication,Humor,OfPersonId,ByPersonId")] Quality quality)
        {
            if (id != quality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualityExists(quality.Id))
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
            return View(quality);
        }

        // GET: Qualities/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quality = await _context.Qualities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quality == null)
            {
                return NotFound();
            }

            return View(quality);
        }

        // POST: Qualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var quality = await _context.Qualities.FindAsync(id);
            _context.Qualities.Remove(quality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualityExists(long id)
        {
            return _context.Qualities.Any(e => e.Id == id);
        }
    }
}
