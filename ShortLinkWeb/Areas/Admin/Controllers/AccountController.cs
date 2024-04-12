using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.Interfaces;
using ShortLink.Infra.Data.Migrations;
using System.Threading.Tasks;

namespace ShortLinkWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("alluser")]
        public async Task<IActionResult> Index() { 
            return View(await _userService.GetUserFors());
        }
    }
}
