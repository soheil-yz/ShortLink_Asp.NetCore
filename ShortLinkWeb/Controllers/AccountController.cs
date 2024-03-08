using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.DTOs.Account;
using ShortLink.Application.Interfaces;
using System.Threading.Tasks;

namespace ShortLinkWeb.Controllers
{
    public class AccountController : SiteBaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }        
        [HttpPost("register") ,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerUser);
                switch (result)
                {
                    case RegisterUserResult.IsMobileExist:
                        TempData[ErrorMassege] = "The phone number entered is duplicate";
                        ModelState.AddModelError("Modile", "The phone number entered is duplicate");
                        break;

					case RegisterUserResult.Success:
						TempData[SuccessMassege] = "Register is Success";
                        return Redirect("/");


				}
			}
            return View(registerUser);
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }         
        [HttpPost("login"),ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            if (ModelState.IsValid)
            {

            }
            return View(loginUser);
        } 
    }
}
