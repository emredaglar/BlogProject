using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _SliderCP:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
