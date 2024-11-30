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
            if (ModelState.IsValid)
            {
                _newsletterService.TInsert(newsletter);
                // Başarılı abone olma işlemi sonrasında JSON döndür
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public PartialViewResult NewsletterFooterSubscribe()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult NewsletterFooterSubscribe(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                _newsletterService.TInsert(newsletter);
                // Başarılı abone olma işlemi sonrasında JSON döndür
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
