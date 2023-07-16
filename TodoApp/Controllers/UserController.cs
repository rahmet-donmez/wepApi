using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.DataContext;
using TodoApp.Entities;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
		Context context=new Context();
		Repository<User> repo = new Repository<User>();

		[HttpPost("login")]
		public ActionResult<Hashtable> Post(String email,String password)
		{
			var value = context.Users.FirstOrDefault(x => x.UserEmail == email
			  && x.UserPassword ==password);
            if (value != null)
            {
				var hash = new Hashtable()
				{
					{"status",true },
					{"user",value }
				};
				

				return hash;
			}
			var hash1 = new Hashtable()
				{
					{"status","false" },
				};


			return hash1;
		}
		[HttpPost("register")]
		public ActionResult<Hashtable> Post(String first_name, String last_name, String phone,String email, String password)
		{
			User user = new User();
			user.UserImg = "temp_img";
			user.UserFirstName = first_name;
			user.UserLastName=last_name;
			user.UserPhone=Int32.Parse(phone);
			user.UserEmail=email;
			user.UserPassword = password;
			repo.Insert(user);
			
				var hash = new Hashtable()
				{
					{"status",true },
					{"user",user }
				};
				return hash;
	
		}
		[HttpPost("delete")]
		public ActionResult<Hashtable> Post(String id)
		{
			var user=repo.GetById(Int32.Parse(id));

			repo.Delete(user);

			var hash = new Hashtable()
				{
					{"status",true },
					{"message","Hesabınız silindi" },

					
				};
			return hash;

		}
		[HttpPost("user")]
		public ActionResult<Hashtable> UserPost(String id)
		{
			var user = repo.GetById(Int32.Parse(id));

			var hash = new Hashtable()
				{
					{"status",true },
					{"user",user },


				};
			return hash;

		}
		[HttpPost("update")]
		public ActionResult<Hashtable> Post(String id,String first_name, String last_name, String phone, String email, String password)
		{
			User user = new User();
			var temp_user=repo.GetById(Int32.Parse(id));
			user.UserImg = temp_user.UserImg;
			user.UserId = Int32.Parse(id);
			user.UserFirstName = first_name;
			user.UserLastName = last_name;
			user.UserPhone = Int32.Parse(phone);
			user.UserEmail = email;
			user.UserPassword = password;
			repo.Update(user);

			var hash = new Hashtable()
				{
					{"status",true },
					{"user",user }
				};
			return hash;

		}
	}
}
