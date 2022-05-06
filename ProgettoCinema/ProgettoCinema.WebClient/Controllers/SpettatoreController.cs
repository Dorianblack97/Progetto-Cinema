#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgettoCinema.ClientWeb.Data;
using ProgettoCinema.Domain;

namespace ProgettoCinema.WebClient.Controllers
{
    public class SpettatoreController : Controller
    {
        private readonly CinemaDbContext _context;

        public SpettatoreController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Spettatore
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }

        // GET: Spettatore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spettatore = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spettatore == null)
            {
                return NotFound();
            }

            return View(spettatore);
        }

        // GET: Spettatore/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spettatore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Birthdate,Id")] Spettatore spettatore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spettatore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spettatore);
        }

        // GET: Spettatore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spettatore = await _context.Persons.FindAsync(id);
            if (spettatore == null)
            {
                return NotFound();
            }
            return View(spettatore);
        }

        // POST: Spettatore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Birthdate,TicketId,OverSeventyYear,UnderFiveYear,Id")] Spettatore spettatore)
        {
            if (id != spettatore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spettatore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpettatoreExists(spettatore.Id))
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
            return View(spettatore);
        }

        // GET: Spettatore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spettatore = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spettatore == null)
            {
                return NotFound();
            }

            return View(spettatore);
        }

        // POST: Spettatore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spettatore = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(spettatore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpettatoreExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
