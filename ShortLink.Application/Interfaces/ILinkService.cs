using shortLink.Domain.Models.Link;
using ShortLink.Application.DTOs.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.Interfaces
{
    public interface ILinkService
    {
        ShortUrl QuickShortUrl (Uri uri);
        Task<UrlRequestResult> AddLink(ShortUrl url); 
         Task AddUserAgent(string userAgent);
    }
}
