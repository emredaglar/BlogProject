using BlogProject.EntityLayer.Concrete;
using BlogProject.PresentationLayer.Areas.Writer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
  
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // Eğer kullanıcı yoksa girişe yönlendir
            }
           
            AppUserViewModel model = new AppUserViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                ImageUrl = user.ImageUrl,
                UserDescription = user.UserDescription
            };
            ModelState.Clear();
        
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserViewModel model
            )
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            model.Name = user.Name ?? "Ad belirtilmemiş";
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.UserName = user.UserName;
            model.ImageUrl = user.ImageUrl;
            model.UserDescription = user.UserDescription;

            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/pluto-1.0.0/images/" + imageName;
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }
                user.ImageUrl = "/pluto-1.0.0/images/" + imageName;
            }

            else
            {
               
                user.ImageUrl = user.ImageUrl ?? "/wwwroot/pluto-1.0.0/images/layout_img/user_img.jpg";
            }

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
            return View(model);
        }
    }
}
