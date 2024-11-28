using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccessLayer.Abstract
{
    public interface IArticleDal:IGenericDal<Article>
    {
        List<Article> ArticleListWithCategory();
        List<Article> ArticleListWithCategoryAndAppUser();
        Article GetLastArticle();
        List<Article> BlogsWithUserAndComment();
        List<Article> SliderBlogsAndCategory();
        List<Article> PopularBlogs();

    }
}
