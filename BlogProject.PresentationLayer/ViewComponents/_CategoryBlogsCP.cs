using BlogProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace BlogProject.PresentationLayer.ViewComponents
{
    public class _CategoryBlogsCP : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryBlogsCP(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TCategorysBlogCount();
            return View(values);
        }
    }
}
