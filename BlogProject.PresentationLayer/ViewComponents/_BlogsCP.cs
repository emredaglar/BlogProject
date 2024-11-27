using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _BlogsCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
