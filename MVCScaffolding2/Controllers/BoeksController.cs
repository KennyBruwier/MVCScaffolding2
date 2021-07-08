using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCScaffolding2.Custom;
using MVCScaffolding2.Data;
using MVCScaffolding2.Models;
using MVCScaffolding2.Models.Db;

namespace MVCScaffolding2.Controllers
{
    public class BoeksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoeksController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Boeks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boeken.ToListAsync());
        }

        // GET: Boeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }
        [Authorize(Roles = "Subscriber,Admin,SuperAdmin,Moderator")]
        // GET: Boeks/Create
        public IActionResult Create()
        {
            return View(new BoekViewModel());
        }

        // POST: Boeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Subscriber,Admin,SuperAdmin,Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Publisher,Auteur,AantalBlz,Taal,Genre,Genres")] BoekViewModel boekVM)
        {
            if (ModelState.IsValid)
            {
                Boek boek = new Boek();
                ViewModelToModel(boekVM, boek);
                _context.Add(boek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boekVM);
        }
        [Authorize(Roles = "Subscriber,Admin,SuperAdmin,Moderator")]
        // GET: Boeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken.FindAsync(id);
            if (boek == null)
            {
                return NotFound();
            }
            return View(ModelToViewModel(boek));
        }

        // POST: Boeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Subscriber,Admin,SuperAdmin,Moderator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Publisher,Auteur,AantalBlz,Taal,Genre,Genres")] BoekViewModel boekVM)
        {
            if (id != boekVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Boek boek = await _context.Boeken.FindAsync(id);
                    if (boek != null)
                    {
                        ViewModelToModel(boekVM, boek);
                        _context.Update(boek);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoekExists(boekVM.Id))
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
            return View(boekVM);
        }
        [Authorize(Roles = "Subscriber,Admin,SuperAdmin,Moderator")]
        // GET: Boeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }

        // POST: Boeks/Delete/5
        [Authorize(Roles = "Subscriber,Admin,SuperAdmin,Moderator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boek = await _context.Boeken.FindAsync(id);
            _context.Boeken.Remove(boek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoekExists(int id)
        {
            return _context.Boeken.Any(e => e.Id == id);
        }
        private BoekViewModel ModelToViewModel(Boek boek)
        {
            return ObjMethods.CopyProperties<Boek, BoekViewModel>(boek);
        }
        private void ViewModelToModel(BoekViewModel boekVM, Boek boek)
        {
            ObjMethods.EditProperties(boekVM, boek);
        }
    }
}
