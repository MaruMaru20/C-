using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewTest20217.Models;

namespace NewTest20217.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PokemonContext _context;

        public PokemonsController(PokemonContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        // GET: Pokemons
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Pokemons.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string cool)
        {
            
            return View(await _context.Pokemons.Where(p => p.PokeName!.Contains(cool)).ToListAsync());

        }


        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .FirstOrDefaultAsync(m => m.PokeId == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // GET: Pokemons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PokeId,PokeName,PokeImage,Memo,PokeDate,PokeImageInTable")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokemon);
        }

        // GET: Pokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PokeId,PokeName,PokeImage,Memo,PokeDate,PokeImageInTable")] Pokemon pokemon)
        {
            if (id != pokemon.PokeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        IFormFile? file = Request.Form.Files.FirstOrDefault();
                        if (file != null && file.Length > 0)
                        {
                            using (var dataStream = new MemoryStream())
                            {
                                await file!.CopyToAsync(dataStream);
                                pokemon.PokeImageInTable = dataStream.ToArray();
                            }
                        }
                    }



                    _context.Update(pokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemon.PokeId))
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
            return View(pokemon);
        }

        // GET: Pokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .FirstOrDefaultAsync(m => m.PokeId == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon != null)
            {
                _context.Pokemons.Remove(pokemon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(e => e.PokeId == id);
        }
    }
}
