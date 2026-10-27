
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookManagement.Models;
using BookManagement.Data;

public class BukusController : Controller
{
    private readonly ApplicationDbContext _context;

    public BukusController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: BUKUS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Bukus.ToListAsync());
    }

    // GET: BUKUS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buku = await _context.Bukus
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buku == null)
        {
            return NotFound();
        }

        return View(buku);
    }

    // GET: BUKUS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BUKUS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Judul,Penulis,JenisBuku,TanggalRilis,JumlahHalaman,JenisBukuNavigation")] Buku buku)
    {
        if (ModelState.IsValid)
        {
            _context.Add(buku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(buku);
    }

    // GET: BUKUS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buku = await _context.Bukus.FindAsync(id);
        if (buku == null)
        {
            return NotFound();
        }
        return View(buku);
    }

    // POST: BUKUS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Judul,Penulis,JenisBuku,TanggalRilis,JumlahHalaman,JenisBukuNavigation")] Buku buku)
    {
        if (id != buku.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(buku);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BukuExists(buku.Id))
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
        return View(buku);
    }

    // GET: BUKUS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buku = await _context.Bukus
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buku == null)
        {
            return NotFound();
        }

        return View(buku);
    }

    // POST: BUKUS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var buku = await _context.Bukus.FindAsync(id);
        if (buku != null)
        {
            _context.Bukus.Remove(buku);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BukuExists(int? id)
    {
        return _context.Bukus.Any(e => e.Id == id);
    }
}
