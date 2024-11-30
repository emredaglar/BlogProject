using BlogProject.BusinessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Controllers
{
    public class ArticleDetailController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleDetailController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public  IActionResult Index(int id)
        {
            var article = _articleService.TGetById(id);
            ViewBag.ArticleId = article.ArticleId;
            var value = _articleService.TArticleDetailWithUserAndComment(id);
            return View(value);
        }
    }
}
