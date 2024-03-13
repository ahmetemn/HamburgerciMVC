using HamburgerciMVC.DATA.Concrate;
using HamburgerMVC.SERVICE.Models.Dtos;
using HamburgerMVC.SERVICE.Models.VMs;
using HamburgerMVC.SERVICE.Service.MenuService;
using HamburgerUI.Areas.AdminPanel.Models;
using HamburgerUI.Models.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(IMenuService menuService, UserManager<AppUser> userManager,
                             SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            this._menuService = menuService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager=roleManager;
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

       

        public IActionResult GetUsers()
        {

            var users =  _userManager.Users.Select(x => new EditUserVM
            {
                Id= x.Id,   
                Email = x.Email,
                UserName = x.UserName



            });
            return View(users); 
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



        [HttpGet] 
        public async Task<IActionResult> GetRole()
        {
            var roles = _roleManager.Roles.Select(x => new GetRoleVM { RoleId = x.Id, RoleName = x.Name });
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new AppRole(roleName));
            if (result.Succeeded)
                return Redirect("GetRole");

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> SetRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _roleManager.Roles.ToListAsync();

            SetRoleVM setRoleVM = new SetRoleVM
            {
                Roles = roles,
                AppUser = user
            };

            return View(setRoleVM);
        }

        [HttpPost]
        public async Task<IActionResult> SetRole(SetRoleVM model, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, model.Role);
            return RedirectToAction("GetUsers");
        }
    }
}
