using BlogProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public PartialViewResult CommentList(int id)
        {
            var values = _commentService.TGetArticeleWithComment(id);
            return PartialView(values);
        }
    }
}
