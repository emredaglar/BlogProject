using System.ComponentModel.DataAnnotations;

namespace BlogProject.PresentationLayer.Areas.Writer.Models
{
    public class AppUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string UserDescription { get; set; }
        public IFormFile Image { get; set; }
    }
}
