using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCinema.Data;
using VCinema.Data.Services;

namespace VCinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync();
            return View(allMovies);
        }
    }
}
