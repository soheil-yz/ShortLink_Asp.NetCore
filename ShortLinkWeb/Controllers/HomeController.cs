using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortLink.Application.DTOs.Links;
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
        public IActionResult Index(UrlRequestDto urlRequest)
        {
            if(ModelState.IsValid)
            {

            }
            return View();
        }

    }
}
