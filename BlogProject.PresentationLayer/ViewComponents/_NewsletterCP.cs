using BlogProject.BusinessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _NewsletterCP : ViewComponent
    {
        private readonly INewsletterService _newsletterService;

        public _NewsletterCP(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
