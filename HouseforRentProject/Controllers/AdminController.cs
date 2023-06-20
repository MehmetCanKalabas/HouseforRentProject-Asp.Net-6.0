using HouseforRentProject.Models.Entity;
using HouseforRentProject.Models.MVVM;
using Microsoft.AspNetCore.Mvc;
using HouseforRentProject.Models.Concrete;
using HouseforRentProject.Models.Service;

namespace HouseforRentProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;
        private readonly VillaService _villaService;
        public AdminController(Context context, VillaService villaService)
        {
            _context = context;
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            return View();
        }


        //public IActionResult UpdateVilla(int id)
        //{
        //    var values = _villaService.GetByID(id);
        //    if (values == null)
        //    {
        //    }
        //    return View();
        //}

        //public IActionResult VillaUpdate(VillaUpdateViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(new Villa()
        //        {
        //            VillaID = model.ID,
        //            Name = model.Name,
        //            Price = model.Price,
        //            Area = model.Area,
        //            Room = model.Room,
        //            Status = true,
        //            Image = model.Image,
        //            Description = model.Description,
        //            City = model.City,
        //        });
        //    }
        //    return RedirectToAction("");
        //}
    }
}
