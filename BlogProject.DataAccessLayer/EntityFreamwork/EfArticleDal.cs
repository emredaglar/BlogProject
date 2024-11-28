using Microsoft.EntityFrameworkCore;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.DataAccessLayer.Context;
using BlogProject.DataAccessLayer.Repositories;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccessLayer.EntityFreamwork
{
	public class EfArticleDal : GenericRepository<Article>, IArticleDal
	{
		public EfArticleDal(BlogContext context) : base(context)
		{
		}

        public List<Article> ArticleListWithCategory()
        {
            var context = new BlogContext();
            var values=context.Articles.Include(x=>x.category).ToList();
            return values;
        }

        public List<Article> ArticleListWithCategoryAndAppUser()
        {
            var context = new BlogContext();
            var values = context.Articles.Include(x => x.category).Include(y=>y.AppUser).ToList();
            return values;
        }
        //bloga ait kullanıcıyı ve yorum sayısını listeleme
        public List<Article> BlogsWithUserAndComment()
        {
            var context = new BlogContext();
            var values=context.Articles.Include(x=>x.AppUser).Include(y=>y.Comments).Include(z=>z.category).ToList();
            return values;
        }

        public Article GetLastArticle()
        {
            var context = new BlogContext();
            var value=context.Articles.OrderByDescending(x=>x.ArticleId).Take(1).FirstOrDefault();
            return value;
        }

        public List<Article> SliderBlogsAndCategory()
        {
            var context = new BlogContext();
            var values= context.Articles.Include(z => z.category).ToList();
            return values;
        }
    }
}
