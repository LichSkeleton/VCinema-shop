using Microsoft.AspNetCore.Mvc;
using VCinema.Data;
using VCinema.Data.Services;

namespace VCinema.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAll();
            return View(allActors);
        }
    }
}
