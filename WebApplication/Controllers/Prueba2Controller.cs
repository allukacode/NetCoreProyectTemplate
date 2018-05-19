using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class Prueba2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Prueba2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prueba2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prueba.ToListAsync());
        }

        // GET: Prueba2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prueba = await _context.Prueba
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prueba == null)
            {
                return NotFound();
            }

            return View(prueba);
        }

        // GET: Prueba2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prueba2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prueba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prueba);
        }

        // GET: Prueba2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prueba = await _context.Prueba.FindAsync(id);
            if (prueba == null)
            {
                return NotFound();
            }
            return View(prueba);
        }

        // POST: Prueba2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre")] Prueba prueba)
        {
            if (id != prueba.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prueba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PruebaExists(prueba.ID))
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
            return View(prueba);
        }

        // GET: Prueba2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prueba = await _context.Prueba
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prueba == null)
            {
                return NotFound();
            }

            return View(prueba);
        }

        // POST: Prueba2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prueba = await _context.Prueba.FindAsync(id);
            _context.Prueba.Remove(prueba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PruebaExists(int id)
        {
            return _context.Prueba.Any(e => e.ID == id);
        }
    }
}
