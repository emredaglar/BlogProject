using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
