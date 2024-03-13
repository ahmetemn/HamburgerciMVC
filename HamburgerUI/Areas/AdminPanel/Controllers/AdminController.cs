using HamburgerciMVC.DATA.Concrate;
using HamburgerMVC.SERVICE.Models.Dtos;
using HamburgerMVC.SERVICE.Models.VMs;
using HamburgerMVC.SERVICE.Service.MenuService;
using HamburgerUI.Models.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HamburgerUI.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class AdminController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IMenuService menuService, UserManager<AppUser> userManager,
                             SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._menuService = menuService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager=roleManager;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Listele", "Admin");
                }
                ModelState.AddModelError(string.Empty, "Gecersiz Giris.");
                return View(model);
            }
            return View(model);
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


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _menuService.Delete(id);
            if (result > 0)
                return RedirectToAction("Listele");
            else
            {
                return Content("Ürün Silinemedi");
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var menu=await _menuService.GetMenu(id); 
            return View(menu);
        }



        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
             var menu =await _menuService.GetMenu(id);

            return View(menu); 
        }

        [HttpPost]

        public IActionResult Update(MenuUpdateVM menuUpdateVM, IFormFile file)
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
            menuUpdateVM.ImagePath = imgName;
            var result = _menuService.Update(menuUpdateVM);

            if (result > 0)
            {
                return RedirectToAction("Listele");
            }

            return View(menuUpdateVM);
        }
        


    }
}
