using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> TArticleListWithCategory();
        List<Article> TArticleListWithCategoryAndAppUser();
        public Article TGetLastArticle();
        List<Article> TBlogsWithUserAndComment();
        List<Article> TSliderBlogsAndCategory();
        List<Article> TPopularBlogs();
        Article TArticleDetailWithUserAndComment(int id);
        List<Article> TGetArticlesByAppUserId(int id);
        public Article TGetArticlesWithCategory(int id);
    }
}
