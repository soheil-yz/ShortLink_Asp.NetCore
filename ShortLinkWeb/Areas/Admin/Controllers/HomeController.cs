using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.Interfaces;
using System.Threading.Tasks;

namespace ShortLinkWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("MyAdmin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
