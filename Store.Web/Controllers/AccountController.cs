using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.UserService;
using Store.Service.UserService.Dtos;

namespace Store.Web.Controllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IUserService _userService;

		public AccountController(IUserService userService)
        {
			_userService = userService;
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
	}
}
