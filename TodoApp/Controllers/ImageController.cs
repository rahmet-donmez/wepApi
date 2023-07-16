using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TodoApp.DataContext;
using TodoApp.Entities;

namespace TodoApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImageController : ControllerBase
	{
Repository<Image> image_repo = new Repository<Image>();
[HttpGet("images")]
		public ActionResult<Hashtable> Get(String product_id)
		{
var images=image_repo.GetListAll(x => x.ProductId == Int32.Parse(product_id));
if(images.Count<=0){
var hash1 = new Hashtable()
				{
					{"status",false },
					
				};
return hash1;
}
else{

			var hash2 = new Hashtable()
				{
					{"status",true },
					{"images", images },
					{"count",images.Count}
				};

			return hash2;


		}}

	}
}
