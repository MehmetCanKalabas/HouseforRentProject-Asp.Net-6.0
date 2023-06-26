using HouseforRentProject.Models.Concrete;
using HouseforRentProject.Models.Entity;
using HouseforRentProject.Models.MVVM;
using HouseforRentProject.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HouseforRentProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VillasController : Controller
    {
        private readonly VillaService _villaService;
        private readonly Context _context;
        public VillasController(VillaService villaService, Context context)
        {
            _villaService = villaService;
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _villaService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddVilla(int id)
        {
            var result = _villaService.GetByID(id);
            if (result == null)
            {
                return View();
            }
            return RedirectToAction("AddVilla", "Villas");
        }

        [HttpPost]
        public async Task<IActionResult> AddVilla(VillaRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Villa villa = new Villa()
                {
                    Name = model.Name,
                    Area = model.Area,
                    City = model.City,
                    Description = model.Description,
                    Image = model.Image,
                    Price = model.Price,
                    Room = model.Room,
                    Status = true,
                };
                await _villaService.AddVillas(villa);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVilla(int id)
        {
            var result = await _villaService.GetByID(id);
            if (result == null || _context.Villas == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVilla(Villa model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    await _villaService.UpdateVilla(model);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            bool answer = _villaService.DeleteVilla(id);
            if (answer == true)
            {
                TempData["Message"] = "Silindi";
            }
            else
            {
                TempData["Message"] = "HATA";
                return RedirectToAction(nameof(DeleteVilla));
            }
            return RedirectToAction("Index", new { message = answer ? "Silindi" : "HATA" });
        }
    }
}