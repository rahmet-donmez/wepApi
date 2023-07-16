using System.ComponentModel.DataAnnotations;

namespace TodoApp.Entities
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public string? ProductExplanation { get; set; }//açıklama

		public string? ProductImg { get; set; }
		public int ProductPrice { get; set; }

		public string ProductCity { get; set; }
		public string ProductDistrict { get; set; }
		public string ProductBrand { get; set; }
		public string ProductModel { get; set; }
		public DateTime Date { get; set; }
		public string ProductKm { get; set; }
		public string ProductColor { get; set; }
		public string ProductStatus { get; set; }

		public int ProductYear { get; set; }
		public string ProductMotorPower { get; set; }



		public int CategoryId { get; set; }
		public Category Category { get; set; }


		public int UserId { get; set; }
		public User User { get; set; }

		List<Image> Images { get; set; }
	}
}
