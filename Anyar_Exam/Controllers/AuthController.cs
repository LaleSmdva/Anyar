using Business.DTOs.Auth;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Anyar_Exam.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RegisterAsync(RegisterDto registerDTO)
		{
			if (!ModelState.IsValid)
			{
				return View(registerDTO);
			}
			if (registerDTO is null) return BadRequest();
			AppUser user = new()
			{
				Fullname = registerDTO.Fullname,
				UserName = registerDTO.Username,
				Email = registerDTO.Email
			};
			var identityResult = await _userManager.CreateAsync(user, registerDTO.Password);

			if (!identityResult.Succeeded)
			{
				foreach (var error in identityResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return Json("ok");
		}

		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{

			var user = await _userManager.FindByEmailAsync(loginDto.UserNameOrEmail);
			if (user is null)
			{
				user = await _userManager.FindByNameAsync(loginDto.UserNameOrEmail);
				if (user is null)
				{
					ModelState.AddModelError("", "Username or password is incorrect");
					return View(loginDto);
				}
			}
			var signInResult = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, true);
			if (!signInResult.Succeeded)
			{
				ModelState.AddModelError("", "Emai/username or pass is incorrect");
				return View(loginDto);
			}
			if (!signInResult.IsLockedOut)
			{
				ModelState.AddModelError("", "Try again later");
				return View(loginDto);
			}
			if (!user.isActive)

			{
				ModelState.AddModelError("", "Emai/username or pass is incorrect");
				return View(loginDto);
			}
			return Json("ok");
		}


		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			if (User.Identity.IsAuthenticated)
			{
				await _signInManager.SignOutAsync();
			}
			return BadRequest();
		}
	}
}
