﻿using Microsoft.AspNetCore.Mvc;
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
        //Get: Cinemas/Details/
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }
        // Get: Cinemas/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            // Check for validation errors only on relevant properties
            ModelState.TryGetValue("Id", out var idError);
            ModelState.TryGetValue("Name", out var nameError);
            ModelState.TryGetValue("Logo", out var logoError);
            ModelState.TryGetValue("Description", out var descriptionError);

            if (idError == null || nameError == null || logoError == null || descriptionError == null)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        // Get: Cinemas/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
