using BlogProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _SliderCP:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _SliderCP(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {


            var values = _articleService.TSliderBlogsAndCategory();
           
            return View(values);
        }
    }
}
