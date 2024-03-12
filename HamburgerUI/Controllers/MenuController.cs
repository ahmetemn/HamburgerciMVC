using Microsoft.AspNetCore.Mvc;

namespace HamburgerUI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
