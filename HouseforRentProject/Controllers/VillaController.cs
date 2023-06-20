using HouseforRentProject.Models.Concrete;
using HouseforRentProject.Models.Entity;
using HouseforRentProject.Models.MVVM;
using HouseforRentProject.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace HouseforRentProject.Controllers
{
    public class VillaController : Controller
    {
        private readonly Context _context;
        private readonly VillaService _villaService;
        public VillaController(Context context, VillaService villaService)
        {
            _context = context;
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            var alls = _villaService.GetAll();
            return View(alls);
        }       
    }
}
