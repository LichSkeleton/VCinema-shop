using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCinema.Data;
using VCinema.Data.Services;
using VCinema.Models;

namespace VCinema.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }
        // Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            // Check for validation errors only on relevant properties
            ModelState.TryGetValue("Name", out var nameError);
            ModelState.TryGetValue("Logo", out var logoError);
            ModelState.TryGetValue("Description", out var descriptionError);

            if (nameError == null || logoError == null || descriptionError == null)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }
    }
}
