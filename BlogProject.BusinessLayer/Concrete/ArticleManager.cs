﻿using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> TArticleListWithCategoryAndAppUser()
        {
            return _articleDal.ArticleListWithCategoryAndAppUser();
        }

        public List<Article> TArticleListWithCategory()
        {
            return _articleDal.ArticleListWithCategory();
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);


        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }

        public Article TGetLastArticle()
        {
           return _articleDal.GetLastArticle();
        }

        public List<Article> TBlogsWithUserAndComment()
        {
            return _articleDal.BlogsWithUserAndComment();
        }

        public List<Article> TSliderBlogsAndCategory()
        {
            return _articleDal.SliderBlogsAndCategory();
        }

        public List<Article> TPopularBlogs()
        {
            return _articleDal.PopularBlogs();
        }

        public Article TArticleDetailWithUserAndComment(int id)
        {
            return _articleDal.ArticleDetailWithUserAndComment(id);
        }

        public List<Article> TGetArticlesByAppUserId(int id)
        {
            return _articleDal.GetArticlesByAppUserId(id);
        }

        public Article TGetArticlesWithCategory(int id)
        {
            return _articleDal.GetArticlesWithCategory(id);
        }
    }
}
