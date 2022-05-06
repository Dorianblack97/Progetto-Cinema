#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgettoCinema.ClientWeb.Data;
using ProgettoCinema.Domain;

namespace ProgettoCinema.WebClient.Controllers
{
    public class BigliettoController : Controller
    {
        private readonly CinemaDbContext _context;

        public BigliettoController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Biglietto
        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Tickets.Include(b => b.CinemaRoom).Include(b => b.Person);
            return View(await cinemaDbContext.ToListAsync());
        }

        // GET: Biglietto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biglietto = await _context.Tickets
                .Include(b => b.CinemaRoom)
                .Include(b => b.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biglietto == null)
            {
                return NotFound();
            }

            return View(biglietto);
        }

        // GET: Biglietto/Create
        public IActionResult Create()
        {
            ViewData["CinemaRoomId"] = new SelectList(_context.CinemaRooms, "Id", "Name");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name");
            return View();
        }

        // POST: Biglietto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Seat,Price,CinemaRoomId,PersonId,Id")] Biglietto biglietto)
        {
            if (ModelState.IsValid)
            {
                biglietto.Person = _context.Persons.Find(biglietto.PersonId);
                biglietto.Price *= Discount(biglietto.Person);
                _context.Add(biglietto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinemaRoomId"] = new SelectList(_context.CinemaRooms, "Id", "Name", biglietto.CinemaRoomId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", biglietto.PersonId);
            return View(biglietto);
        }

        // GET: Biglietto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biglietto = await _context.Tickets.FindAsync(id);
            if (biglietto == null)
            {
                return NotFound();
            }
            ViewData["CinemaRoomId"] = new SelectList(_context.CinemaRooms, "Id", "Name", biglietto.CinemaRoomId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", biglietto.PersonId);
            return View(biglietto);
        }

        // POST: Biglietto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Seat,Price,CinemaRoomId,PersonId,Id")] Biglietto biglietto)
        {
            if (id != biglietto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biglietto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BigliettoExists(biglietto.Id))
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
            ViewData["CinemaRoomId"] = new SelectList(_context.CinemaRooms, "Id", "Name", biglietto.CinemaRoomId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Name", biglietto.PersonId);
            return View(biglietto);
        }

        // GET: Biglietto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biglietto = await _context.Tickets
                .Include(b => b.CinemaRoom)
                .Include(b => b.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biglietto == null)
            {
                return NotFound();
            }

            return View(biglietto);
        }

        // POST: Biglietto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biglietto = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(biglietto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BigliettoExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
        private float Discount(Spettatore person)
        {
            var discount = 1f;
            if (person.OverSeventyYear)
            {
                discount = 0.90f;
                return discount;
            }
            if (person.UnderFiveYear)
            {
                discount = 0.50f;
                return discount;
            }
            return discount;
        }
    }
}
