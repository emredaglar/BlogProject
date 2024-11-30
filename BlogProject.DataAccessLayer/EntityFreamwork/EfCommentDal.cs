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
        
    }
}
