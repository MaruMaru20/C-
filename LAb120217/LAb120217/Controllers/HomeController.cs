using System.Diagnostics;
using LAb120217.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAb120217.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonsContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PokemonsContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pokemons.ToListAsync());
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
