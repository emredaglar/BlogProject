using BlogProject.BusinessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, IArticleService articleService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var commentList = _commentService.TGetCommentsByAppUserId(userValue.Id);
            return View(commentList);
            
        }
    }
}
