using BlogProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _BlogsCP : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogsCP(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            int page = 1;
            int pageSize = 4; // Sayfa başına gösterilecek makale sayısı

            // URL'deki 'page' parametresini al
            if (HttpContext.Request.Query.TryGetValue("page", out var pageValue))
            {
                int.TryParse(pageValue, out page);
            }

            // Makaleleri getir ve sayfalama uygula
            var allArticles = _articleService.TBlogsWithUserAndComment();
            var pagedArticles = allArticles
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Toplam sayfa sayısını hesapla
            ViewBag.TotalPages = (int)Math.Ceiling((double)allArticles.Count() / pageSize);
            ViewBag.CurrentPage = page;

            return View(pagedArticles);
        }
    }
}
