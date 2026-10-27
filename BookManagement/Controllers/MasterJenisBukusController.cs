
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookManagement.Models;
using BookManagement.Data;

public class MasterJenisBukusController : Controller
{
    private readonly ApplicationDbContext _context;

    public MasterJenisBukusController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MASTERJENISBUKUS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.MasterJenisBukus.ToListAsync());
    }

    // GET: MASTERJENISBUKUS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var masterjenisbuku = await _context.MasterJenisBukus
            .FirstOrDefaultAsync(m => m.Id == id);
        if (masterjenisbuku == null)
        {
            return NotFound();
        }

        return View(masterjenisbuku);
    }

    // GET: MASTERJENISBUKUS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MASTERJENISBUKUS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,JenisBuku,Bukus")] MasterJenisBuku masterjenisbuku)
    {
        if (ModelState.IsValid)
        {
            _context.Add(masterjenisbuku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(masterjenisbuku);
    }

    // GET: MASTERJENISBUKUS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var masterjenisbuku = await _context.MasterJenisBukus.FindAsync(id);
        if (masterjenisbuku == null)
        {
            return NotFound();
        }
        return View(masterjenisbuku);
    }

    // POST: MASTERJENISBUKUS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,JenisBuku,Bukus")] MasterJenisBuku masterjenisbuku)
    {
        if (id != masterjenisbuku.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(masterjenisbuku);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterJenisBukuExists(masterjenisbuku.Id))
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
        return View(masterjenisbuku);
    }

    // GET: MASTERJENISBUKUS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var masterjenisbuku = await _context.MasterJenisBukus
            .FirstOrDefaultAsync(m => m.Id == id);
        if (masterjenisbuku == null)
        {
            return NotFound();
        }

        return View(masterjenisbuku);
    }

    // POST: MASTERJENISBUKUS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var masterjenisbuku = await _context.MasterJenisBukus.FindAsync(id);
        if (masterjenisbuku != null)
        {
            _context.MasterJenisBukus.Remove(masterjenisbuku);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MasterJenisBukuExists(int? id)
    {
        return _context.MasterJenisBukus.Any(e => e.Id == id);
    }
}
