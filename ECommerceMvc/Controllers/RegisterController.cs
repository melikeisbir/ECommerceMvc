using ECommerceMvc.Dto;
using ECommerceMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMvc.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            AppUser appuser = new AppUser()
            {
                FirstName = appUserRegisterDto.FirstName,
                LastName = appUserRegisterDto.LastName,
                UserName = appUserRegisterDto.UserName,
                Email = appUserRegisterDto.Email
            };

            if (appUserRegisterDto.Password == appUserRegisterDto.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appuser, appUserRegisterDto.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(appUserRegisterDto);
        }
    }
}
