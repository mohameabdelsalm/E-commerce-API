using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Entites.IdentityEntites;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.TokenService
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;
		private readonly SymmetricSecurityKey _Key;

		public TokenService(IConfiguration configuration)
        {
			_configuration = configuration;
			_Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
		}
        public string GenerateToken(AppUser appUser)
		{
			//First Create Claims Of User and Create Custom Type if you Contain Thing In ClaimTypes
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email,appUser.Email),
				new Claim(ClaimTypes.GivenName,appUser.DisplayName),
				new Claim("UserId",appUser.Id),
				new Claim("UserName",appUser.UserName),
			};

			//Second Create SigningCredentials That Contain Key Should be Encoding and Algorithms
			var creads = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha256);

			//Thiry Add Details That Created Such Creads and Claims InTokenDescriptoer 
			var TokenDescriptoer = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Issuer = _configuration["Token:Issuer"],
				IssuedAt = DateTime.Now,
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = creads,
				
			};

			//Finally Assign Which We Use In Token By TokenHandelrs
			var TokenHanderl = new JwtSecurityTokenHandler();
			var token = TokenHanderl.CreateToken(TokenDescriptoer);
			return TokenHanderl.WriteToken(token);
		}
	}
}
