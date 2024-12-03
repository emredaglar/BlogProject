using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.DataAccessLayer.EntityFreamwork;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

    
        public void TDelete(int id)
		{
			_commentDal.Delete(id);
		}

		public List<Comment> TGetAll()
		{
			return _commentDal.GetAll();
		}

        public List<Comment> TGetArticeleWithComment(int articleId)
        {
            return _commentDal.GetArticeleWithComment(articleId);
        }

        public Comment TGetById(int id)
		{
			return _commentDal.GetById(id);
		}

        public List<Comment> TGetCommentsByAppUserId(int id)
        {
			return _commentDal.GetCommentsByAppUserId(id);
        }

        public void TInsert(Comment entity)
		{
			_commentDal.Insert(entity);
		}

		public void TUpdate(Comment entity)
		{
			_commentDal.Update(entity);
		}
	}
}
