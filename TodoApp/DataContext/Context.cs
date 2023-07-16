using Microsoft.EntityFrameworkCore;
using TodoApp.Entities;

namespace TodoApp.DataContext
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=E-Commerce; integrated security=true; encrypt=false");


		}
		public DbSet<User> Users { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Image> Images { get; set; }
	}
}
