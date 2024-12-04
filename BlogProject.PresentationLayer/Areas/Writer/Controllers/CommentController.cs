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
        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var values= _commentService.TGetCommentById(id,userValue.Id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            
            var newComment = _commentService.TGetCommentById(comment.CommentId, userValue.Id);
            newComment.Detail = comment.Detail;
            newComment.CreatedDate = DateTime.Now;
            _commentService.TUpdate(newComment);
            return RedirectToAction("Index", "Comment");
        }
        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
