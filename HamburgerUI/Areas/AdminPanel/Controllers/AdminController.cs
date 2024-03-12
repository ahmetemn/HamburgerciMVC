using HamburgerciMVC.DATA.Concrate;
using HamburgerMVC.SERVICE.Models.Dtos;
using HamburgerMVC.SERVICE.Service.MenuService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerUI.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class AdminController : Controller
    {
        private readonly IMenuService _menuService;


        public AdminController(IMenuService menuService)
        {
            this._menuService = menuService;
        }

        public async Task<IActionResult> Listele()
        {
            var data = await _menuService.GetAllMenu();
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public IActionResult Create(MenuCreateDTO model, IFormFile file)
        {
            string imgName = "default.png";

            if (file != null)
            {

                string imgExtension = Path.GetExtension(file.FileName);
                imgName = Guid.NewGuid() + imgExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/hamburgerPhoto/{imgName}");
                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);

            }
            model.ImagePath = imgName;
            var result = _menuService.Create(model);

            if (result > 0)
            {
                return RedirectToAction("Listele");
            }

                return BadRequest();




        }
    }


}
