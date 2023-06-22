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
        public VillasController(VillaService villaService)
        {
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            var values = _villaService.GetAll();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddVilla(int id)
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
                return RedirectToAction("AddVilla","Villas","Admin");
            }
            return RedirectToAction("Index");
        }
    }
}
