using HouseforRentProject.Models.Concrete;
using HouseforRentProject.Models.Entity;
using HouseforRentProject.Models.MVVM;
using HouseforRentProject.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace HouseforRentProject.Controllers
{
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
        public IActionResult AddVilla()
        {
            return View();
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
            return RedirectToAction("Index");
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
                    return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}