using Store.Data.Entites.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.TokenService
{
	public interface ITokenService
	{
		string GenerateToken(AppUser appUser);
	}
}
