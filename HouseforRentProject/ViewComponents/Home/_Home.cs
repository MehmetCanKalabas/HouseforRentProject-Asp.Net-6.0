
using HouseforRentProject.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace HouseforRentProject.ViewComponents.Home
{
    public class _Home : ViewComponent
    {
        private readonly VillaService _service;
        public _Home(VillaService service)
        {
            _service = service;
        }
        public IViewComponentResult Invoke()
        {
            var values = _service.GetAll();
            return View(values);
        }
    }
}