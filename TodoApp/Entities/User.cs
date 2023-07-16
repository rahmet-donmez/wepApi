using System.ComponentModel.DataAnnotations;

namespace TodoApp.Entities
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
		public string UserEmail { get; set; }
		public string UserPassword { get; set; }
		public string UserImg { get; set; }
		public int UserPhone { get; set; }


		List<Product> Products { get; set; }





	}
}
