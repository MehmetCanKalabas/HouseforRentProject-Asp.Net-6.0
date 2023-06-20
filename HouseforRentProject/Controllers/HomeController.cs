using Microsoft.AspNetCore.Mvc;

namespace HouseforRentProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
