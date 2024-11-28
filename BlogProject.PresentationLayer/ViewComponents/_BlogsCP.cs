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
            var values = _articleService.TBlogsWithUserAndComment();
            return View(values);
        }

    }
}
