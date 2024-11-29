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
		public EfCommentDal(BlogContext context) : base(context)
		{
		}

        public List<Comment> GetArticeleWithComment(int articleId)
        {
            var context = new BlogContext();
            var values = context.Comments
                                 .Where(x => x.ArticleId == articleId)  // Belirtilen makale ID'sine ait yorumlar
                                 .Include(x => x.Article)  // Yorumlar ile ilgili makale bilgilerini dahil et
                                 .ToList();
            return values;
        }
    }
}
