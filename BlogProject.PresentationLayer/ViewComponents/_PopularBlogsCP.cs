using Microsoft.AspNetCore.Mvc;
namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _PopularBlogsCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
