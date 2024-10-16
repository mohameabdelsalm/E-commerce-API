using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entites.IdentityEntites;
using Store.Service.UserService;
using Store.Service.UserService.Dtos;
using System.Security.Claims;

namespace Store.Web.Controllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly UserManager<AppUser> _userManager;
		public AccountController(IUserService userService,UserManager<AppUser> userManager)
        {
			_userService = userService;
			_userManager=userManager;
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> Login(LoginDto Model)
		{
			var user=await _userService.Login(Model);
			if (user == null)
				return BadRequest(Model);
			return Ok(user);
			
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> Register(RegisterDto Model)
		{
			var user = await _userService.Register(Model);
			if (user == null)
				return BadRequest(Model);
			return Ok(user);

		}
		[HttpPost]
		[Authorize]
		public async Task<UserDto> GetCurrentUserAsync()
		{
			var userId = User?.FindFirst("UserId");
			var user = await _userManager.FindByIdAsync(userId.Value);

			return new UserDto 
			{
				Id=Guid.Parse(user.Id),
				DisplayName=user.DisplayName,
				Email=user.Email
			};
		}
	}
}
