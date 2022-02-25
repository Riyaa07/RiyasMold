using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiyasMold.Data;
using RiyasMold.Models;

namespace RiyasMold.Controllers
{
    public class IceController : Controller
    {
        private readonly RiyasMoldContext _context;

        public IceController(RiyasMoldContext context)
        {
            _context = context;
        }

        // GET: Ice
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Ice.ToListAsync());
        }*/

        /*public async Task<IActionResult> Index(string searchString)
        {
            var ice = from m in _context.Ice
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                ice = ice.Where(s => s.Shape!.Contains(searchString));
            }

            return View(await ice.ToListAsync());
        }*/

        // GET: Movies
        public async Task<IActionResult> Index(string iceSize, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Ice
                                            orderby m.Size
                                            select m.Size;
            var movies = from m in _context.Ice
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Shape!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(iceSize))
            {
                movies = movies.Where(x => x.Size == iceSize);
            }

            var movieGenreVM = new IceSizeViewModel
            {
                Sizes = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Ices = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        /*public async Task<IActionResult> Index(string id)
        {
            var ice = from m in _context.Ice
                         select m;

            if (!String.IsNullOrEmpty(id))
            {
                ice = ice.Where(s => s.Shape!.Contains(id));
            }

            return View(await ice.ToListAsync());
        }*/

        // GET: Ice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ice = await _context.Ice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ice == null)
            {
                return NotFound();
            }

            return View(ice);
        }

        // GET: Ice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Size,Grids,Color,Shape,Price,Material,Ratings")] Ice ice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ice);
        }

        // GET: Ice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ice = await _context.Ice.FindAsync(id);
            if (ice == null)
            {
                return NotFound();
            }
            return View(ice);
        }

        // POST: Ice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Size,Grids,Color,Shape,Price,Material,Ratings")] Ice ice)
        {
            if (id != ice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IceExists(ice.Id))
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
            return View(ice);
        }

        // GET: Ice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ice = await _context.Ice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ice == null)
            {
                return NotFound();
            }

            return View(ice);
        }

        // POST: Ice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ice = await _context.Ice.FindAsync(id);
            _context.Ice.Remove(ice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IceExists(int id)
        {
            return _context.Ice.Any(e => e.Id == id);
        }
    }
}
