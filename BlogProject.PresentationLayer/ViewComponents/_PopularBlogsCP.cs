using BlogProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _PopularBlogsCP : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _PopularBlogsCP(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TPopularBlogs();
            return View(values);
        }
    }
}
