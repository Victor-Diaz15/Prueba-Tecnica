using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba_Tecnica.Core.Application.Interfaces.Services;
using Prueba_Tecnica.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandidatoService _candidatoService;
        public HomeController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        public async Task<IActionResult> Index()
        {
            List<CandidatoViewModel> candidatosVm = await _candidatoService.GetAllAsync();
            return View(candidatosVm);
        }
        public IActionResult SaveCandidate()
        {
            return View(new SaveCandidatoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SaveCandidate(SaveCandidatoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            SaveCandidatoViewModel response = await _candidatoService.AddAsync(vm);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        public async Task<IActionResult> UpdateCandidate(int id)
        {
            SaveCandidatoViewModel vm = await _candidatoService.GetById(id);
            return View("SaveCandidate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCandidate(SaveCandidatoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveCandidate", vm);
            }
            
            SaveCandidatoViewModel response = await _candidatoService.UpdateAsync(vm, vm.Id);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View("SaveCandidate", vm);
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            SaveCandidatoViewModel vm = await _candidatoService.GetById(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCandidate(SaveCandidatoViewModel vm)
        {
            await _candidatoService.DeleteAsync(vm.Id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
