using System.ComponentModel.DataAnnotations;

namespace TodoApp.Entities
{
	public class Image
	{
		[Key]
		public int ImageId { get; set; }
		public string ImagePath { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

	}
}
