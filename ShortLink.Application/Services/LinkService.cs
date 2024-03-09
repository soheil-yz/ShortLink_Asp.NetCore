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

        public ShortUrl QuickShortUrl(Uri uri)
        {
            var shortUrl = new ShortUrl();
            shortUrl.orginalUrl = uri;
            shortUrl.CreateData = DateTime.Now;
            shortUrl.Token = Generate.Token();
            shortUrl.Value = new Uri($"http://localhost:44356/{shortUrl.Token}");
            return shortUrl;


        }
    }
}
 