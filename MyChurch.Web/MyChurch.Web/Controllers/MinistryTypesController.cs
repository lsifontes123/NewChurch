using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyChurch.Web.Data;
using MyChurch.Web.Data.Entities;

namespace MyChurch.Web.Controllers
{
    public class MinistryTypesController : Controller
    {
        private readonly DataContext _context;

        public MinistryTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: MinistryTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MinistryTypes.ToListAsync());
        }

        // GET: MinistryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ministryType = await _context.MinistryTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ministryType == null)
            {
                return NotFound();
            }

            return View(ministryType);
        }

        // GET: MinistryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MinistryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MinistryType ministryType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ministryType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ministryType);
        }

        // GET: MinistryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ministryType = await _context.MinistryTypes.FindAsync(id);
            if (ministryType == null)
            {
                return NotFound();
            }
            return View(ministryType);
        }

        // POST: MinistryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MinistryType ministryType)
        {
            if (id != ministryType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ministryType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinistryTypeExists(ministryType.Id))
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
            return View(ministryType);
        }

        // GET: MinistryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ministryType = await _context.MinistryTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ministryType == null)
            {
                return NotFound();
            }

            return View(ministryType);
        }

        // POST: MinistryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ministryType = await _context.MinistryTypes.FindAsync(id);
            _context.MinistryTypes.Remove(ministryType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinistryTypeExists(int id)
        {
            return _context.MinistryTypes.Any(e => e.Id == id);
        }
    }
}
