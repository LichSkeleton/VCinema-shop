using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCinema.Data;
using VCinema.Data.Services;
using VCinema.Models;

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

        //GET: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            // Check for validation errors only on relevant properties
            ModelState.TryGetValue("ProfilePictureURL", out var profilePictureUrlError);
            ModelState.TryGetValue("FullName", out var fullNameError);
            ModelState.TryGetValue("Bio", out var bioError);

            if (fullNameError == null || profilePictureUrlError == null || bioError == null) return View(producer);

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        // Get: producers/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            // Check for validation errors only on relevant properties
            ModelState.TryGetValue("Id", out var idError);
            ModelState.TryGetValue("FullName", out var fullNameError);
            ModelState.TryGetValue("ProfilePictureURL", out var profilePictureUrlError);
            ModelState.TryGetValue("Bio", out var bioError);

            if (idError == null || fullNameError == null || profilePictureUrlError == null || bioError == null) return View(producer);
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
    }
}
