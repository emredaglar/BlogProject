using BlogProject.BusinessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }
        [HttpGet]
        public PartialViewResult NewsletterSubscribe()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult NewsletterSubscribe(Newsletter newsletter)
        {
          
            _newsletterService.TInsert(newsletter);
            return RedirectToAction("Index","Default");
        }
        [HttpGet]
        public PartialViewResult NewsletterFooterSubscribe()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult NewsletterFooterSubscribe(Newsletter newsletter)
        {

            _newsletterService.TInsert(newsletter);
            return RedirectToAction("Index", "Default");
        }
    }
}
