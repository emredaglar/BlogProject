using BlogProject.DataAccessLayer.Abstract;
using BlogProject.DataAccessLayer.Context;
using BlogProject.DataAccessLayer.Repositories;
using BlogProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccessLayer.EntityFreamwork
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly BlogContext _context;
        public EfCommentDal(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Comment> GetArticeleWithComment(int articleId)
        {

            var values = _context.Comments
                   .Where(x => x.ArticleId == articleId)
                   .Include(x => x.Article)
                   .Include(x => x.AppUser)
                   .ToList();
            return values;
        }

        public Comment GetCommentById(int commentId, int userId)
        {
            var context = new BlogContext();


            var comment = context.Comments
                .Where(x => x.CommentId == commentId && x.AppUserId == userId)
                .Include(x => x.Article)
                .Include(x => x.AppUser)
                .FirstOrDefault();
            return comment;
        }
        public List<Comment> GetCommentsByAppUserId(int id)
        {
            var context = new BlogContext();
            var values = context.Comments.Where(x => x.AppUserId == id).Include(x => x.Article).Include(y => y.AppUser).ToList();
            return values;
        }
    }


}
