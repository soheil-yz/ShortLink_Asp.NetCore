using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shortLink.Domain.Interface;
using ShortLink.Application.DTOs.Links;
using ShortLink.Application.Interfaces;
using ShortLink.Application.Services;
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
        private readonly ILinkService _services;

        public HomeController(ILinkService services)
        {
            _services = services;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UrlRequestDto urlRequest)
        {
            if(ModelState.IsValid)
            {
                if (urlRequest.OrginalUrl.Contains("https://") ||
                    urlRequest.OrginalUrl.Contains("http://"))
                {
                    var url = new Uri(urlRequest.OrginalUrl);
                    var shortUrl = _services.QuickShortUrl(url);

                    var result = await _services.AddLink(shortUrl);
                    switch (result)
                    {
                        case UrlRequestResult.Error:
                            TempData[ErrorMassege] = "Has Problem";
                            break;
                        case UrlRequestResult.Success:
                            TempData[SuccessMassege] = "Your link has been shortened successfully";
                            ViewBag.IsSuccess = true;
                            ViewBag.UserShortLink = shortUrl.Value.ToString();
                            break;
                    }
                }
                else
                {
                    TempData[ErrorMassege] = "Pls Complite Your Link With http:// Or https://";
                    return View(urlRequest);
                }
            }
            return View(urlRequest);
        }

    }
}
