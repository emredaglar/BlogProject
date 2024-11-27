using Microsoft.AspNetCore.Mvc;
namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _NewsletterCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
