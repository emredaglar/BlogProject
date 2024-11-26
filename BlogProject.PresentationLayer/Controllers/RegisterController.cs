using BlogProject.EntityLayer.Concrete;
using BlogProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Controllers
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
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
           

            AppUser appUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                Surname = registerViewModel.Surname,
                UserName = registerViewModel.UserName,
                ImageUrl = "test"
            };
            var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);

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
                return View(registerViewModel);
            }
           
        }
    }
}
