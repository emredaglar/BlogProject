using Microsoft.AspNetCore.Mvc;
namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _CategoryBlogsCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
