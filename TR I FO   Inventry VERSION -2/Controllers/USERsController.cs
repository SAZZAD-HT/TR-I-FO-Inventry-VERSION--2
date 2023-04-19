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

    public class USERsController : Controller
    {
        private readonly context _context;

        public USERsController(context context)
        {
            _context = context;
        }

        // GET: USERs
        public async Task<IActionResult> Index()
        {
              return _context.AccountInfo != null ? 
                          View(await _context.AccountInfo.ToListAsync()) :
                          Problem("Entity set 'context.AccountInfo'  is null.");
        }

        // GET: USERs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountInfo == null)
            {
                return NotFound();
            }

            var uSER = await _context.AccountInfo
                .FirstOrDefaultAsync(m => m.User_id == id);
            if (uSER == null)
            {
                return NotFound();
            }

            return View(uSER);
        }

        // GET: USERs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: USERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_id,User_name,UserType,Password")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uSER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uSER);
        }

        // GET: USERs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountInfo == null)
            {
                return NotFound();
            }

            var uSER = await _context.AccountInfo.FindAsync(id);
            if (uSER == null)
            {
                return NotFound();
            }
            return View(uSER);
        }

        // POST: USERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_id,User_name,UserType,Password")] USER uSER)
        {
            if (id != uSER.User_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uSER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!USERExists(uSER.User_id))
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
            return View(uSER);
        }

        // GET: USERs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountInfo == null)
            {
                return NotFound();
            }

            var uSER = await _context.AccountInfo
                .FirstOrDefaultAsync(m => m.User_id == id);
            if (uSER == null)
            {
                return NotFound();
            }

            return View(uSER);
        }

        // POST: USERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountInfo == null)
            {
                return Problem("Entity set 'context.AccountInfo'  is null.");
            }
            var uSER = await _context.AccountInfo.FindAsync(id);
            if (uSER != null)
            {
                _context.AccountInfo.Remove(uSER);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool USERExists(int id)
        {
          return (_context.AccountInfo?.Any(e => e.User_id == id)).GetValueOrDefault();
        }
        public IActionResult ShowUser()
        {
            return View();
        }
        
    }
}
