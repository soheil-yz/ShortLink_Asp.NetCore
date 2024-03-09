using shortLink.Domain.Interface;
using shortLink.Domain.Models.Link;
using ShortLink.Application.DTOs.Links;
using ShortLink.Application.Generetor;
using ShortLink.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace ShortLink.Application.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _repository;

        public LinkService(ILinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<UrlRequestResult> AddLink(ShortUrl url)
        {
            if (url == null) return UrlRequestResult.Error;
            await _repository.AddLink(url);
            await _repository.SaveChange();
            return UrlRequestResult.Success;    
        }

        public async Task AddUserAgent(string userAgent)
        {
            var uaParser = Parser.GetDefault();
            ClientInfo client = uaParser.Parse(userAgent);

            var Os = new Os
            {
                Family = client.OS.Family,
                Major = client.OS.Major,
                //Minor = client.OS.Minor,
                Minor = "hi",
                CreateData = DateTime.Now,
            };
            await _repository.AddOs(Os);
            //await _repository.SaveChange();
            var device = new shortLink.Domain.Models.Link.Device
            {
                IsBot = client.Device.IsSpider,
                Brand = client.Device.Brand,
                Family = client.Device.Family,
                Model = client.Device.Model,    
                CreateData = DateTime.Now
            };
            await _repository.AddDevice(device);

            var brower = new Browser 
            {  
             Family = client.UA.Family,
             Major = client.UA.Major,
             Minor = client.UA.Minor,
             CreateData = DateTime.Now,
            };
            await _repository.AddBrower(brower);

        }

        public ShortUrl FindUrlByToken(string token)
        {
            return _repository.FindUrlByToken(token);
        }

        public ShortUrl QuickShortUrl(Uri uri)
        {
            var shortUrl = new ShortUrl();
            shortUrl.orginalUrl = uri;
            shortUrl.CreateData = DateTime.Now;
            shortUrl.Token = Generate.Token();
            shortUrl.Value = new Uri($"https://localhost:44356/{shortUrl.Token}");
            return shortUrl;


        }
    }
}
 