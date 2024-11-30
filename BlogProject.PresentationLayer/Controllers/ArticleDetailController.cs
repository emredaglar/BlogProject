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

            //Önceki ve Sonraki Bloglar----------------------------------------------
            var prevArticle = _articleService.TGetAll()
                .Where(a => a.ArticleId < id)
                .OrderByDescending(a => a.ArticleId)
                .FirstOrDefault();

            var nextArticle = _articleService.TGetAll()
                .Where(a => a.ArticleId > id)
                .OrderBy(a => a.ArticleId)
                .FirstOrDefault();

            ViewBag.PrevArticle = prevArticle;
            ViewBag.NextArticle = nextArticle;

            //Önceki ve Sonraki Bloglar----------------------------------------------


            // Newsletter nesnesi oluşturuluyor ve ViewBag'e ekleniyor
            var newsletter = new Newsletter();
            ViewBag.Newsletter = newsletter;

            var value = _articleService.TArticleDetailWithUserAndComment(id);
            return View(value);  // Article detail ve yorumları içeriyor
        }

    }
}
