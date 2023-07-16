using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoApp.DataContext;
using TodoApp.Entities;

namespace TodoApp.DataContext
{
	public class Repository<T> where T : class
	{
	

		public void Delete(T t)
		{
			using var context = new Context();
			context.Remove(t);
			context.SaveChanges();
		}

		public T GetById(int id)
		{
			using var context = new Context();
			return context.Set<T>().Find(id);
		}

		public void Insert(T t)
		{
			using var context = new Context();
			context.Add(t);
			context.SaveChanges();
		}

		//kategoriye yada kişiye göre filtreleme
		public List<T> GetListAll(Expression<Func<T, bool>> filter)
		{
			using var context = new Context();

			return context.Set<T>().Where(filter).ToList();



		}
		public List<Product> GetCategoryByListAll(String id, String alt, String ust)
		{
			using var context = new Context();

			List<Product> sonuc;
			if (alt != "0")
			{

				sonuc = context.Products.Where(x => x.CategoryId == int.Parse(id)).Where(x => x.ProductPrice >= Int32.Parse(alt) && x.ProductPrice <= Int32.Parse(ust)).ToList();
			}
			else
			{

				sonuc = context.Products.Where(x => x.CategoryId == int.Parse(id)).ToList();
			}

			return sonuc;


		}
		public List<Product> GetUserByListAll(String id,String alt,String ust)
		{
			using var context = new Context();

List<Product> sonuc;
if (alt != "0")
			{

				sonuc = context.Products.Where(x => x.UserId == int.Parse(id)).Where(x => x.ProductPrice >=  Int32.Parse(alt) && x.ProductPrice <= Int32.Parse(ust)).ToList();
}
else{

sonuc = context.Products.Where(x => x.UserId == int.Parse(id)).ToList();}
			
return sonuc;


		}
		public List<Product> ListAllUserFilterFiyatAzalan(String id, String alt, String ust)
		{
			using var context = new Context();
			//var sonuc = context.Products.FromSql($"SELECT * FROM Products WHERE UserId={id} ORDER BY ProductPrice DESC").ToList();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => x.UserId == int.Parse(id)).Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderByDescending(x => x.ProductPrice).ToList();


			}
			else
			{			
				sonuc = context.Products.Where(x => x.UserId == int.Parse(id)).OrderByDescending(x=>x.ProductPrice).ToList();


			}
			return sonuc;
		}
		public List<Product> ListAllUserFilterFiyatArtan(String id,String alt, String ust)
		{
			using var context = new Context();
			//	var sonuc = context.Products.FromSql($"SELECT * FROM Products WHERE UserId={id} ORDER BY ProductPrice ASC").ToList();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => x.UserId == int.Parse(id)).Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderBy(x => x.ProductPrice).ToList();


			}
			else
			{
				sonuc = context.Products.Where(x => x.UserId == int.Parse(id)).OrderBy(x => x.ProductPrice).ToList();


			}
			return sonuc;
		}
		public List<T> CategoryListAll()
		{
			using var context = new Context();
			return context.Set<T>().ToList();
		}
		public List<Product> ListAll( String alt, String ust)
		{
			
		
				using var context = new Context();

				List<Product> sonuc;
				if (alt != "0")
				{

					sonuc = context.Products.Where(x => x.ProductPrice >= Int32.Parse(alt) && x.ProductPrice <= Int32.Parse(ust)).ToList();
				}
				else
				{

					sonuc = context.Products.ToList();
				}

				return sonuc;


			
			//using var context = new Context();
			//return context.Set<T>().ToList();
		}
		public List<Product> ListAllFiyatArtan(String alt, String ust)
		{
			using var context = new Context();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc=context.Products.Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderBy(x => x.ProductPrice).ToList();
			}
			else
			{
				sonuc= context.Products.OrderBy(x => x.ProductPrice).ToList();
			}
			
			
			

			return sonuc;
		}
		public List<Product> ListAllFiyatAzalan(String alt, String ust)
		{
			using var context = new Context();
			//var sonuc = context.Products.FromSql($"SELECT * FROM Products ORDER BY ProductPrice DESC").ToList();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderByDescending(x => x.ProductPrice).ToList();
			}
			else
			{
				sonuc = context.Products.OrderByDescending(x => x.ProductPrice).ToList();
			}
			return sonuc;
		}
		public List<Product> ListAllCategoryFilterFiyatAzalan(int id,String alt, String ust)
		{
			using var context = new Context();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => x.CategoryId == id).Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderByDescending(x => x.ProductPrice).ToList();


			}
			else
			{
				sonuc = context.Products.Where(x => x.CategoryId == id).OrderByDescending(x => x.ProductPrice).ToList();


			}
			//var sonuc = context.Products.FromSql($"SELECT * FROM Products WHERE CategoryId={id} ORDER BY ProductPrice DESC").ToList();
			
			return sonuc;
		}
		public List<Product> ListAllCategoryFilterFiyatArtan(int id,String alt, String ust)
		{
			using var context = new Context();
			//var sonuc = context.Products.FromSql($"SELECT * FROM Products WHERE CategoryId={id} ORDER BY ProductPrice ASC").ToList();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => x.CategoryId == id).Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderBy(x => x.ProductPrice).ToList();
			}
			else
			{
				sonuc = context.Products.Where(x => x.CategoryId == id).OrderBy(x => x.ProductPrice).ToList();
			}
			return sonuc;
		}
		public List<Product> SeachProducts(String search, String alt, String ust)
		{
			//var param = new SqlParameter("param", search);
			///var sonuc = context.Products.FromSql($"SELECT * FROM Products({search})").Include(x => x.ProductName).ToList();
			//	var sonuc = context.Products.FromSqlRaw($"SELECT * FROM Products WHERE ProductName LIKE '@param'", param).ToList();

			using var context = new Context();
			var param = "%" + search + "%";
			//var sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor+x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).ToList();
			//var sonuc = context.Products.FromSqlRaw($"SELECT * FROM Products WHERE ProductName LIKE '{search}'",search).ToList();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).ToList();
			}
			else
			{
				sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).ToList();
			}
			return sonuc;
		}
		public List<Product> SeachProductsFiyatArtan(String search, String alt, String ust)
		{
			using var context = new Context();
			var param = "%" + search + "%";
			//var sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).OrderBy(x=>x.ProductPrice).ToList();
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderBy(x => x.ProductPrice).ToList();
			}
			else
			{
				sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).OrderBy(x => x.ProductPrice).ToList();
			}

			return sonuc;
		}
		public List<Product> SeachProductsFiyatAzalan(String search, String alt, String ust)

		{
			using var context = new Context();
			var param = "%" + search + "%";
			//var sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).OrderByDescending(x => x.ProductPrice).ToList();
			
			List<Product> sonuc;
			if (alt != "0")
			{
				sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).Where(x => x.ProductPrice >= int.Parse(alt) && x.ProductPrice <= int.Parse(ust)).OrderByDescending(x => x.ProductPrice).ToList();
			}
			else
			{
				sonuc = context.Products.Where(x => EF.Functions.Like(x.ProductName + x.ProductColor + x.ProductBrand + x.ProductCity + x.ProductDistrict + x.ProductExplanation + x.ProductModel + x.ProductStatus, param)).OrderByDescending(x => x.ProductPrice).ToList();
			}

			return sonuc;
			
		}
		public void Update(T t)
		{
			using var context = new Context();
			context.Update(t);
			context.SaveChanges();
		}
	}
}

