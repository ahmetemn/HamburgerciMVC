using HamburgerMVC.SERVICE.Service.MenuService;
using HamburgerUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HamburgerUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly IMenuService _menuService; 
        public HomeController(ILogger<HomeController> logger , IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        
        }

        public async Task<IActionResult> Index()
        {

            var data = await _menuService.GetAllMenu();
            return View(data);
        
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetMenuForName(int id)
        {


            var burger = await _menuService.GetMenu(id); 


            return View(burger); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}