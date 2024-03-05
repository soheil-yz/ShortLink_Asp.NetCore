using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortLinkWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLinkWeb.Controllers
{
    public class HomeController : SiteBaseController 
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
