using Microsoft.AspNetCore.Mvc;
using VCinema.Data;

namespace VCinema.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;
        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allProdusers = _context.Actors.ToList();
            return View();
        }
    }
}
