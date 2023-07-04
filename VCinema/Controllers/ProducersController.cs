using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCinema.Data;
using VCinema.Data.Services;

namespace VCinema.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }
    }
}
