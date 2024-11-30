using BlogProject.BusinessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public PartialViewResult CommentList(int id)
        {
            var values = _commentService.TGetArticeleWithComment(id);
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult AddComment(int articleId)
        {
            //ViewBag.ArticleId = articleId;
            return PartialView();
           
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CreatedDate = DateTime.Now;

            comment.AppUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _commentService.TInsert(comment);

            return RedirectToAction("Index", "ArticleDetail", new { id = comment.ArticleId });
        }
    }
}
