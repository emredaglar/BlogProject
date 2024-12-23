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
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

        public List<Category> TCategorysBlogCount()
        {
           return _categoryDal.CategorysBlogCount();
        }

        public void TDelete(int id)
		{
			_categoryDal.Delete(id);
		}

		public List<Category> TGetAll()
		{
			return _categoryDal.GetAll();
		}

		public Category TGetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public void TInsert(Category entity)
		{
			if (entity.CategoryName.Length>=5&&entity.CategoryName.Length<=50)
			{
				_categoryDal.Insert(entity);
			}
			else
			{
				//error
			}
		}

		public void TUpdate(Category entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
