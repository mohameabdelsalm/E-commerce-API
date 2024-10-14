using Microsoft.AspNetCore.Identity;
using Store.Data.Entites.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
	public class SeedingIdentityUser
	{
		public static async Task SeedUserAsync(UserManager<AppUser> userManager) 
		{
			if (!userManager.Users.Any())
			{
				var user=new AppUser() 
				{
					DisplayName="Mohamed Abdelsalam",
					Email="abdelsalamm789@gmail.com",
					UserName="mohamedabdelsalam",
					Address=new Address 
					{
						FristName="Mohamed",
						LastName="Abdelsalam",
						City="Qaluab",
						State="Qalubiaya",
						street="13",
						PostalCode="1235"
					}

				};
				await userManager.CreateAsync(user,"Password11@");
			}
		}
	}
}
