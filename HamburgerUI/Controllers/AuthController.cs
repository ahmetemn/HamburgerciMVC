using HamburgerciMVC.DATA.Concrate;
using HamburgerciMVC.REPO.Context;
using HamburgerUI.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;

namespace HamburgerUI.Controllers
{
	public class AuthController : Controller
    {


       
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager; 

        public AuthController(ApplicationContext applicationContext , UserManager<AppUser> userManager, SignInManager<AppUser> signInManager , RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager=roleManager;

        }


        public IActionResult Index()
		{
			return View();
		}


  //      [HttpPost]
		//public async  Task<IActionResult> Register(RegisterVM loginVM)
		//{

  //          var user = new AppUser
  //          {
  //              UserName = loginVM.UserName,
  //              Email = loginVM.Email,
  //              PhoneNumber = loginVM.PhoneNumber,

  //          }; 
  //          var result = await _userManager.CreateAsync(user,loginVM.Password);  
  //          if (result.Succeeded)
  //          {

  //              await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
  //              return  RedirectToAction("Index", "Home"); 
  //          }

  //          else
  //          {

  //              foreach(IdentityError item in  result.Errors)
  //              {
  //                  ModelState.AddModelError("", item.Description);
  //              }
  //          }


		//	return View("Index"); 
		//}


        [HttpPost]
        public async Task<IActionResult> Login(RegisterVM model )
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password , false , false);

                if (result.Succeeded)
                {
                  
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Hatalı Kullanıcı Adı veya Şifre");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
