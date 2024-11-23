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
	public class EfTagCloudDal : GenericRepository<TagCloud>, ITagCloudDal
	{
		public EfTagCloudDal(BlogContext context) : base(context)
		{
		}
	}
}
