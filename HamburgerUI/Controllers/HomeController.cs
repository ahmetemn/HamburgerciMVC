using HamburgerciMVC.DATA.Concrate;
using HamburgerMVC.SERVICE.Service.MenuService;
using HamburgerUI.Models;
using HamburgerUI.Models.VMs;
using Microsoft.AspNetCore.Http;
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

       

        List<SiparisVM> siparisVMs = new List<SiparisVM>();
        public ActionResult SepetListele(string burgerAdi , double ToplamFiyat , List<EkstraMalzeme> ekstraMalzemes) {

            SiparisVM siparis = new SiparisVM()
            {
                UrunAdi = burgerAdi,
                Fiyat = ToplamFiyat,
                Adet=1,
                EkstraMalzemes = ekstraMalzemes
            };
            siparisVMs .Add(siparis);
            return View(siparisVMs); 
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}