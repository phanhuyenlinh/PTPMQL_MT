using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class EmployeeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employeee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employeee.ToListAsync());
        }

        // GET: Employeee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeee = await _context.Employeee
                .FirstOrDefaultAsync(m => m.cancuoccongdan == id);
            if (employeee == null)
            {
                return NotFound();
            }

            return View(employeee);
        }

        // GET: Employeee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employeee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cancuoccongdan,hoten,quequan")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeee);
        }

        // GET: Employeee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeee = await _context.Employeee.FindAsync(id);
            if (employeee == null)
            {
                return NotFound();
            }
            return View(employeee);
        }

        // POST: Employeee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("cancuoccongdan,hoten,quequan")] Employeee employeee)
        {
            if (id != employeee.cancuoccongdan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeeExists(employeee.cancuoccongdan))
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
            return View(employeee);
        }

        // GET: Employeee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeee = await _context.Employeee
                .FirstOrDefaultAsync(m => m.cancuoccongdan == id);
            if (employeee == null)
            {
                return NotFound();
            }

            return View(employeee);
        }

        // POST: Employeee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employeee = await _context.Employeee.FindAsync(id);
            if (employeee != null)
            {
                _context.Employeee.Remove(employeee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeeExists(string id)
        {
            return _context.Employeee.Any(e => e.cancuoccongdan == id);
        }
    }
}
