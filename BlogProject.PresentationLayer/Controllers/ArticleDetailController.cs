using BlogProject.BusinessLayer.Abstract;
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

        public IActionResult Index(int id)
        {
            var value = _articleService.TArticleDetailWithUserAndComment(id);
            return View(value);
        }
    }
}
