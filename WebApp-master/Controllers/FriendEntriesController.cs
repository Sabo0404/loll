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
    public class FriendEntriesController : Controller
    {
        private readonly MainContex _context;

        public FriendEntriesController(MainContex context)
        {
            _context = context;
        }

        // GET: FriendEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.FriendEntrys.ToListAsync());
        }

        // GET: FriendEntries/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendEntry = await _context.FriendEntrys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendEntry == null)
            {
                return NotFound();
            }

            return View(friendEntry);
        }

        // GET: FriendEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FriendEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstPersonId,SecondPersonId")] FriendEntry friendEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friendEntry);
        }

        // GET: FriendEntries/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendEntry = await _context.FriendEntrys.FindAsync(id);
            if (friendEntry == null)
            {
                return NotFound();
            }
            return View(friendEntry);
        }

        // POST: FriendEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstPersonId,SecondPersonId")] FriendEntry friendEntry)
        {
            if (id != friendEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendEntryExists(friendEntry.Id))
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
            return View(friendEntry);
        }

        // GET: FriendEntries/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendEntry = await _context.FriendEntrys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendEntry == null)
            {
                return NotFound();
            }

            return View(friendEntry);
        }

        // POST: FriendEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var friendEntry = await _context.FriendEntrys.FindAsync(id);
            _context.FriendEntrys.Remove(friendEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendEntryExists(long id)
        {
            return _context.FriendEntrys.Any(e => e.Id == id);
        }
    }
}
