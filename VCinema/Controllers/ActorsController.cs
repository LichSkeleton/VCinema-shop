using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VCinema.Data;
using VCinema.Data.Services;
using VCinema.Models;

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
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }
        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            // Check for validation errors only on relevant properties
            ModelState.TryGetValue("FullName", out var fullNameError);
            ModelState.TryGetValue("ProfilePictureURL", out var profilePictureUrlError);
            ModelState.TryGetValue("Bio", out var bioError);

            if (fullNameError == null || profilePictureUrlError == null || bioError == null)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/
        //[AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        // Get: Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            // Check for validation errors only on relevant properties
            ModelState.TryGetValue("Id", out var idError);
            ModelState.TryGetValue("FullName", out var fullNameError);
            ModelState.TryGetValue("ProfilePictureURL", out var profilePictureUrlError);
            ModelState.TryGetValue("Bio", out var bioError);

            if (idError == null || fullNameError == null || profilePictureUrlError == null || bioError == null)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
        // Get: Actors/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);            
            return RedirectToAction(nameof(Index));
        }
    }
}
