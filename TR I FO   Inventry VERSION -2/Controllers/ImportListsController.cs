using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TR_I_FO___Inventry_VERSION__2.Models;
using TR_I_FO___Inventry_VERSION__2.Models.Databases;

namespace TR_I_FO___Inventry_VERSION__2.Controllers
{
    public class ImportListsController : Controller
    {
        private readonly context _context;

        public ImportListsController(context context)
        {
            _context = context;
        }

        // GET: ImportLists
        public async Task<IActionResult> Index()
        {
              return _context.Imports != null ? 
                          View(await _context.Imports.ToListAsync()) :
                          Problem("Entity set 'context.Imports'  is null.");
        }

        // GET: ImportLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Imports == null)
            {
                return NotFound();
            }

            var importList = await _context.Imports
                .FirstOrDefaultAsync(m => m.Import == id);
            if (importList == null)
            {
                return NotFound();
            }

            return View(importList);
        }

        // GET: ImportLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImportLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Import,sProduct_name,country,sDescription,d_Quantity,cust_quantity")] ImportList importList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importList);
        }

        // GET: ImportLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Imports == null)
            {
                return NotFound();
            }

            var importList = await _context.Imports.FindAsync(id);
            if (importList == null)
            {
                return NotFound();
            }
            return View(importList);
        }

        // POST: ImportLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Import,sProduct_name,country,sDescription,d_Quantity,cust_quantity")] ImportList importList)
        {
            if (id != importList.Import)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportListExists(importList.Import))
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
            return View(importList);
        }

        // GET: ImportLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Imports == null)
            {
                return NotFound();
            }

            var importList = await _context.Imports
                .FirstOrDefaultAsync(m => m.Import == id);
            if (importList == null)
            {
                return NotFound();
            }

            return View(importList);
        }

        // POST: ImportLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Imports == null)
            {
                return Problem("Entity set 'context.Imports'  is null.");
            }
            var importList = await _context.Imports.FindAsync(id);
            if (importList != null)
            {
                _context.Imports.Remove(importList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportListExists(int id)
        {
          return (_context.Imports?.Any(e => e.Import == id)).GetValueOrDefault();
        }
    }
}
