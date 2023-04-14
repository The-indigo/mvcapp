using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcapp.Data;
using mvcapp.Models;

namespace mvcapp.Controllers
{
    public class TextAddedsController : Controller
    {
        private readonly mvcappContext _context;

        public TextAddedsController(mvcappContext context)
        {
            _context = context;
        }

        // GET: TextAddeds
        public async Task<IActionResult> Index()
        {
              return _context.TextAdded != null ? 
                          View(await _context.TextAdded.ToListAsync()) :
                          Problem("Entity set 'mvcappContext.TextAdded'  is null.");
        }

        // GET: TextAddeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TextAdded == null)
            {
                return NotFound();
            }

            var textAdded = await _context.TextAdded
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textAdded == null)
            {
                return NotFound();
            }

            return View(textAdded);
        }

        // GET: TextAddeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TextAddeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] TextAdded textAdded)
        {
            if (ModelState.IsValid)
            {
                _context.Add(textAdded);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(textAdded);
        }

        // GET: TextAddeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TextAdded == null)
            {
                return NotFound();
            }

            var textAdded = await _context.TextAdded.FindAsync(id);
            if (textAdded == null)
            {
                return NotFound();
            }
            return View(textAdded);
        }

        // POST: TextAddeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] TextAdded textAdded)
        {
            if (id != textAdded.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(textAdded);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextAddedExists(textAdded.Id))
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
            return View(textAdded);
        }

        // GET: TextAddeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TextAdded == null)
            {
                return NotFound();
            }

            var textAdded = await _context.TextAdded
                .FirstOrDefaultAsync(m => m.Id == id);
            if (textAdded == null)
            {
                return NotFound();
            }

            return View(textAdded);
        }

        // POST: TextAddeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TextAdded == null)
            {
                return Problem("Entity set 'mvcappContext.TextAdded'  is null.");
            }
            var textAdded = await _context.TextAdded.FindAsync(id);
            if (textAdded != null)
            {
                _context.TextAdded.Remove(textAdded);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextAddedExists(int id)
        {
          return (_context.TextAdded?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
