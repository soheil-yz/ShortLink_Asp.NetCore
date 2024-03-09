using shortLink.Domain.Interface;
using shortLink.Domain.Models.Link;
using ShortLink.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Infra.Data.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly ShortLinkContext _context;

        public LinkRepository(ShortLinkContext context)
        {
            _context = context;
        }

        public async Task AddBrower(Browser browser)
        {
            await _context.Browsers.AddAsync(browser);
        }

        public async Task AddDevice(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public async Task AddLink(ShortUrl url)
        {
            await _context.ShortUrls.AddAsync(url);
        }

        public async Task AddOs(Os os)
        {
            await _context.Os.AddAsync(os);
        }

        public async ValueTask DisposeAsync()
        {
            if (_context != null) 
                await _context.DisposeAsync();
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
