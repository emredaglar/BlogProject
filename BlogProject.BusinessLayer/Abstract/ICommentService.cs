using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Abstract
{
	public interface ICommentService : IGenericService<Comment>
	{
        public List<Comment> TGetArticeleWithComment(int articleId);
        public List<Comment> TGetCommentsByAppUserId(int id);

    }
}
