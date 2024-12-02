using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
