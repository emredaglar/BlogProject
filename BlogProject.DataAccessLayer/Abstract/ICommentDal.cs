using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccessLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        List<Comment> GetArticeleWithComment(int articleId);
        public List<Comment> GetCommentsByAppUserId(int id);
        public Comment GetCommentById(int commentId, int userId);
    }
}
