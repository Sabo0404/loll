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
    public class CitizenshipsController : Controller
    {
        private readonly MainContex _context;

        public CitizenshipsController(MainContex context)
        {
            _context = context;
        }

        // GET: Citizenships
        public async Task<IActionResult> Index()
        {
            var query = from Citizenship in _context.Citizenships
                        join City in _context.Cities on Citizenship.CityId equals City.Id
                        join Person in _context.Persons on Citizenship.PersonId equals Person.Id
                        select new CitizenshipView
                        {
                            Citizenship = Citizenship,
                            PersonName = Person.Name,
                            CityName = City.Name
                        };
            return View(await query.ToListAsync());
        }

        // GET: Citizenships/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizenship = await _context.Citizenships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citizenship == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", citizenship.PersonId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", citizenship.CityId);
            return View(citizenship);
        }

        // GET: Citizenships/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }

        // POST: Citizenships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,CityId")] Citizenship citizenship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citizenship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citizenship);
        }

        // GET: Citizenships/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizenship = await _context.Citizenships.FindAsync(id);
            if (citizenship == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", citizenship.PersonId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", citizenship.CityId);
            return View(citizenship);
        }

        // POST: Citizenships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PersonId,CityId")] Citizenship citizenship)
        {
            if (id != citizenship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citizenship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitizenshipExists(citizenship.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", citizenship.PersonId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", citizenship.CityId);
            return View(citizenship);
        }

        // GET: Citizenships/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizenship = await _context.Citizenships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citizenship == null)
            {
                return NotFound();
            }

            return View(citizenship);
        }

        // POST: Citizenships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var citizenship = await _context.Citizenships.FindAsync(id);
            _context.Citizenships.Remove(citizenship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<ActionResult> MustBeUniqueCitizenship(long PersonId, long CityId)
        {
            if (_context.Citizenships.Any(x=> x.CityId == CityId && x.PersonId == PersonId))
            {
                return Json("Duplicate found");
            }

            return Json(true);
        }

        private bool CitizenshipExists(long id)
        {
            return _context.Citizenships.Any(e => e.Id == id);
        }
    }
}
