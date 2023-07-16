using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TodoApp.DataContext;
using TodoApp.Entities;

namespace TodoApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		Repository<Category> repo = new Repository<Category>();
		[HttpPost]
		public ActionResult<Category> Post(String categoryName)
		{
			using var context = new Context();
			Category category = new Category();
			category.CategoryName = categoryName;
			repo.Insert(category);
			//context.Categories.Add(category);
			//context.SaveChanges();

			return category;
		}
		[HttpPost("categories")]
		public ActionResult<Hashtable> Post()
		{
			
			var hash = new Hashtable()
				{
					{"status",true },
					{"categories",repo.CategoryListAll() }
				};

			return hash;
		}
	}
}
