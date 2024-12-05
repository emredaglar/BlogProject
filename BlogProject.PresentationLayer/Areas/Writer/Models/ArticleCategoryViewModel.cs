using BlogProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.PresentationLayer.Areas.Writer.Models
{
	public class ArticleCategoryViewModel
	{
		public Article Article { get; set; }
		public Category Category { get; set; }
		public List<SelectListItem> CategoryList { get; set; }
	}
}
