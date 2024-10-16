using Microsoft.AspNetCore.Identity;
using Store.Data.Entites.IdentityEntites;
using Store.Service.TokenService;
using Store.Service.UserService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.UserService
{
	public class UserService : IUserService
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly ITokenService _token;

		public UserService(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,ITokenService token)
        {
			_signInManager = signInManager;
			_userManager = userManager;
			_token = token;
		}
        public async Task<UserDto> Login(LoginDto input)
		{
			var user = await _userManager.FindByEmailAsync(input.Email);
			if (user == null)
				return null;

			var check = await _signInManager.CheckPasswordSignInAsync(user,input.Password,false);

			if (!check.Succeeded)
				throw new Exception("Failed Login");

			return new UserDto
			{
				Id = Guid.Parse(user.Id),
				Email = user.Email,
				DisplayName = user.DisplayName,
				Token = _token.GenerateToken(user)

			}; 
		}

		public async Task<UserDto> Register(RegisterDto input)
		{
			var user = await _userManager.FindByEmailAsync(input.Email);
			if (user is not null)
				return null;

			var CreateUser = new AppUser
			{
				DisplayName= input.DisplayName,
				Email = input.Email,
				UserName = input.DisplayName,
			};
			var Create=await _userManager.CreateAsync(CreateUser,input.Password);
			if (Create.Succeeded)
				return new UserDto
				{
					Id = Guid.Parse(CreateUser.Id),
					Email = CreateUser.Email,
					DisplayName = CreateUser.DisplayName,
					Token = _token.GenerateToken(CreateUser)

				};

			throw new Exception("Is InValied");


		}
	}
}
