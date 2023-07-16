using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TodoApp.DataContext;
using TodoApp.Entities;

namespace TodoApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		Repository<Product> product_repo = new Repository<Product>();
		Repository<User> user_repo = new Repository<User>();

		[HttpGet("products")]
		public ActionResult<Hashtable> GetProducts(int siralama,String alt,String ust)
		{
			List<Product> products;
			switch (siralama)
			{
				case 0:
					products = product_repo.ListAll(alt,ust);
					
					break;
				case 1:
					products = product_repo.ListAll(alt,ust);
					 products.Reverse();
					break;
				case 2:
					products = product_repo.ListAllFiyatArtan(alt,ust);
					break;
				case 3:
					products = product_repo.ListAllFiyatAzalan(alt,ust);
					break;
				default:
					products = product_repo.ListAll(alt,ust);

					break;
			};

			bool status = true;
			if (products.Count() == 0)
			{
				status = false;
			}
			var hash = new Hashtable()
				{
					{"status",status },
					{"products",products}
				};

			return hash;


		}
		[HttpGet("searchProducts")]
		public ActionResult<Hashtable> SearchProducts(int siralama,String search, String alt, String ust)
		{
		
			List<Product> products;
			switch (siralama)
			{
				case 0:
					products = product_repo.SeachProducts(search,alt,ust);
					
					break;
				case 1:
					products = product_repo.SeachProducts(search, alt, ust);
					products.Reverse();
					break;
				case 2:
					products = product_repo.SeachProductsFiyatArtan(search, alt, ust);
					break;
				case 3:
					products = product_repo.SeachProductsFiyatAzalan(search, alt, ust);
					break;
				default:
					products = product_repo.SeachProducts(search, alt, ust);

					break;
			};

			bool status = true;
			if (products.Count() == 0)
			{
				status = false;
			}
			var hash = new Hashtable()
				{
					{"status",status },
					{"products",products}
				};

			return hash;


		}

		

		[HttpGet("sonProducts")]
		public ActionResult<Hashtable> GetSonProducts()
		{
var values=product_repo.ListAll("0","0");
values.Reverse();
            List<Product> products=new List<Product>();
            for(int i = 0; i < 8; i++)
            {
                products.Add(values[i]);
            }
			var hash = new Hashtable()
				{
					{"status",true },
					{"products",products}
				};

			return hash;


		}
[HttpGet("myProducts")]
		public ActionResult<Hashtable> GetMyProduct(String user_id,int siralama,String alt, String ust)
		{

			List<Product> products;
			switch (siralama)
			{
				case 0:
					products = product_repo.GetUserByListAll(user_id,alt,ust);

					break;
				case 1:
					products = product_repo.GetUserByListAll(user_id,alt,ust);
					products.Reverse();
					break;
				case 2:
					products = product_repo.ListAllUserFilterFiyatArtan(user_id,alt,ust);
					break;
				case 3:
					products = product_repo.ListAllUserFilterFiyatAzalan(user_id, alt,ust);
					break;
				default:
					products = product_repo.GetListAll(x => x.UserId == Int32.Parse(user_id));
					break;
			};
			bool status = true;
			if (products.Count() == 0)
			{
				status = false;
			}
			var hash = new Hashtable()
				{
					{"status",status },
					{"products",products}
				};


			return hash;


		}
		[HttpGet("filterProducts")]
		public ActionResult<Hashtable> GetCatgeoryFilter(String category_id,int siralama, String alt, String ust)
		{


			List<Product> products;
			switch (siralama)
			{
				case 0:
					products = product_repo.GetCategoryByListAll(category_id, alt, ust);

					break;
				case 1:
					products = product_repo.GetCategoryByListAll(category_id, alt, ust);
					products.Reverse();
					break;
				case 2:
					products = product_repo.ListAllCategoryFilterFiyatArtan(int.Parse(category_id), alt, ust);
					break;
				case 3:
					products = product_repo.ListAllCategoryFilterFiyatAzalan(int.Parse(category_id), alt, ust);
					break;
				default:
					products = product_repo.GetCategoryByListAll( category_id, alt, ust);

					break;
			};

			bool status = true;
			if (products.Count() == 0)
			{
				status = false;
			}
			var hash = new Hashtable()
				{
					{"status",status },
					{"products",products}
				};


			return hash;

		


		}
		[HttpGet("product")]
		public ActionResult<Hashtable> Get(String id)
		{
			var product =product_repo.GetById(Int32.Parse(id));
			var user=user_repo.GetById(product.UserId);

		
			var hash = new Hashtable()
				{
					{"status",true },
					{"product",product },
				{"user",user }
				};

			return hash;


		}
		[HttpPost("delete")]
		public ActionResult<Hashtable> Post(String id)
		{
			var product = product_repo.GetById(Int32.Parse(id));

			product_repo.Delete(product);


			var hash = new Hashtable()
				{
					{"status",true },
					
				};

			return hash;


		}



		[HttpPost("add")]
		public ActionResult<Hashtable> Post(String user_id,String ad, String aciklama, String renk, String marka, 
			String model, String yil, 
			String motor_gucu, String km, String sehir, String semt, String durum, String fiyat,int kategori)
		{
			Product product=new Product();


			product.ProductExplanation = aciklama;
			product.ProductName = ad;
			product.ProductPrice = Int32.Parse(fiyat);
			product.ProductBrand =marka;
product.ProductImg ="defaultProduct.png";
			product.ProductCity = semt;
			product.ProductDistrict =sehir ;
			product.ProductKm = km;
			product.ProductModel = model;
			product.ProductYear = Int32.Parse(yil);
			product.ProductColor = renk;
			product.Date = DateTime.Now;
			product.ProductMotorPower = motor_gucu;
			product.ProductStatus = durum;
			product.UserId = Int32.Parse(user_id); //userId;
			product.CategoryId = kategori;

			product_repo.Insert(product);


			var hash = new Hashtable()
				{
					{"status",true },
					{"product",product },
				
				};

			return hash;


		}
		[HttpPost("update")]
		public ActionResult<Hashtable> Post(String user_id,String product_id, String ad, String aciklama, String renk, String marka,
			String model, String yil,
			String motor_gucu, String km, String sehir, String semt, String durum, String fiyat)
		{
			Product product = new Product();

			product.ProductId= Int32.Parse(product_id);
			product.ProductExplanation = aciklama;
			product.ProductName = ad;
			product.ProductPrice = Int32.Parse(fiyat);
			product.ProductBrand = sehir;
			product.ProductCity = semt;
			product.ProductDistrict = marka;
			product.ProductKm = km;
			product.ProductModel = model;
			product.ProductYear = Int32.Parse(yil);
			product.ProductColor = renk;
			product.Date = DateTime.Now;
			product.ProductMotorPower = motor_gucu;
			product.ProductStatus = durum;
			product.UserId = Int32.Parse(user_id); //userId;
			product.CategoryId = 1;

			product_repo.Update(product);


			var hash = new Hashtable()
				{
					{"status",true },
					{"product",product },

				};

			return hash;


		}




		[HttpPost]
		public IActionResult Post(Product product)
		{
			using var context = new Context();

			context.Products.Add(product);
			context.SaveChanges();

			return StatusCode(201);

		}

	}
}
