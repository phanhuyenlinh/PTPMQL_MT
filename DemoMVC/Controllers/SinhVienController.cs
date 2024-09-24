using DEMOMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DEMOMVC.Models;
using MVC.Models;

namespace MVC.Controllers;
public class SinhVienController : Controller
{
    private readonly ApplicationDbContext _context;

        public SinhVienController(ApplicationDbContext context)
        {
            _context = context;
        }
    public async Task<IActionResult> Index()
    {
        return View(await _context.SinhVien.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SinhVien sv)
    {
        if (ModelState.IsValid)
        {
            _context.Add(sv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(sv);
    }

    public async Task<IActionResult> Edit(string id)
    {
        if (id == null || _context.SinhVien == null)
         {
            return NotFound();
        }

        var sv = await _context.SinhVien.FindAsync(id);
        if (sv == null)
        {
            return NotFound();
        }
        return View(sv);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, SinhVien sv)
    {
        if (id != sv.SVID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(sv);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhVienExists(sv.SVID))
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
        return View(sv);
    }
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var sv = await _context.SinhVien
            .FirstOrDefaultAsync(m => m.SVID == id);
        if (sv == null)
        {
            return NotFound();
        }
        return View(sv);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var sv = await _context.SinhVien.FindAsync(id);
        if (sv != null)
        {
            _context.SinhVien.Remove(sv);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool SinhVienExists(string id)
    {
        return _context.SinhVien.Any(e => e.SVID == id);
    }
}
