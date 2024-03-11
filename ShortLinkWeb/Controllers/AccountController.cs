using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.DTOs.Account;
using ShortLink.Application.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Claims;
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
                var result = await _userService.LoginUser(loginUser);
                switch(result)
                {
                    case LoginUserResult.NotFound:
                        TempData[ErrorMassege] = "User NotFound";
                        break;
                    case LoginUserResult.NotActivate:
                        TempData[WarningMassege] = "This User is not Actiove";
                        break;
                    case LoginUserResult.Success:
                        var user = await _userService.GetUserByMobile(loginUser.Mobile);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.Mobile),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim("IsAdmin" , user.IsAdmin.ToString())
                        };
                        var identoty = new  ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identoty);
                        var properties = new AuthenticationProperties
                        {
                                IsPersistent = loginUser.RememberMe,
                        };
                        await HttpContext.SignInAsync(principle, properties);
                        TempData[SuccessMassege] = "You Are Login Now";
                        return RedirectToAction("index" , "Home");
                        
                }
            }
            return View(loginUser);
        } 

       public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            TempData[SuccessMassege] = "Your Account LogOut Now";
            return RedirectToAction("index", "Home");
        }
    }
}
