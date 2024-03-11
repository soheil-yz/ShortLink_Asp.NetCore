using Microsoft.AspNetCore.Mvc;

namespace ShortLinkWeb.Areas.Admin.Controllers
{

    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
