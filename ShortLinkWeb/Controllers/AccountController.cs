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
