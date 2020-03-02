using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyChurch.Web.Data;
using MyChurch.Web.Data.Entities;

namespace MyChurch.Web.Controllers
{
   
    public class DisciplesController : Controller
    {
        private readonly DataContext _context;

        public DisciplesController(DataContext context)
        {
            _context = context;
        }

        // GET: Disciples
        public IActionResult Index()
        {
            return View(_context.Disciples.Include(a => a.User));
        }

        // GET: Disciples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciple = await _context.Disciples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciple == null)
            {
                return NotFound();
            }

            return View(disciple);
        }

        // GET: Disciples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disciples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Disciple disciple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciple);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciple);
        }

        // GET: Disciples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciple = await _context.Disciples.FindAsync(id);
            if (disciple == null)
            {
                return NotFound();
            }
            return View(disciple);
        }

        // POST: Disciples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Disciple disciple)
        {
            if (id != disciple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscipleExists(disciple.Id))
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
            return View(disciple);
        }

        // GET: Disciples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciple = await _context.Disciples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciple == null)
            {
                return NotFound();
            }

            return View(disciple);
        }

        // POST: Disciples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciple = await _context.Disciples.FindAsync(id);
            _context.Disciples.Remove(disciple);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscipleExists(int id)
        {
            return _context.Disciples.Any(e => e.Id == id);
        }
    }
}
