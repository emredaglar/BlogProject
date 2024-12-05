using BlogProject.BusinessLayer.Abstract;
using BlogProject.BusinessLayer.ValidationRules;
using BlogProject.EntityLayer.Concrete;
using BlogProject.PresentationLayer.Areas.Writer.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class WriteController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;


        public WriteController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var articleList = _articleService.TGetArticlesByAppUserId(userValue.Id);
            return View(articleList);
        }
        public async Task<IActionResult> DetailArticle(int id)
        {
            var value = _articleService.TGetArticlesWithCategory(id);
            return View(value);
        }
		[HttpGet]
		public IActionResult CreateArticle()
		{
			var categoryList = _categoryService.TGetAll();

			var model = new ArticleCategoryViewModel
			{
				Article = new Article(),
				Category = new Category(),
				CategoryList = categoryList.Select(x => new SelectListItem
				{
					Text = x.CategoryName,
					Value = x.CategoryId.ToString()
				}).ToList()
			};

			model.CategoryList.Insert(0, new SelectListItem { Text = "Kategori seçiniz", Value = "" });
			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> CreateArticle(ArticleCategoryViewModel model)
		{
			if (model.Article == null)
			{
				ModelState.AddModelError("", "Article is null");
				return View(model);
			}
			
			var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

			model.Article.AppUserId = userValue.Id;
			model.Article.CreatedDate = DateTime.Now;

			CreateArticleValidator validationRules = new CreateArticleValidator();
			ValidationResult result = validationRules.Validate(model.Article);

			if (result.IsValid)
			{
				_articleService.TInsert(model.Article);
				return RedirectToAction("MyArticleList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			// Kategori listesini yeniden doldur
			var categoryList = _categoryService.TGetAll();
			model.CategoryList = categoryList.Select(x => new SelectListItem
			{
				Text = x.CategoryName,
				Value = x.CategoryId.ToString()
			}).ToList();
			model.CategoryList.Insert(0, new SelectListItem { Text = "Kategori seçiniz", Value = "" });


			return View(model);
		}

		public IActionResult DeleteArticle(int id)
		{
			_articleService.TDelete(id);
			return RedirectToAction("MyArticleList");
		}

	}
}
