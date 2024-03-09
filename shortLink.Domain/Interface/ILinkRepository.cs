using shortLink.Domain.Models.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Interface
{
    public interface ILinkRepository : IAsyncDisposable
    {
        Task AddLink(ShortUrl url);
        Task AddOs(Os os);
        Task AddDevice(Device device);
        Task AddBrower(Browser browser);

        Task SaveChange();

    }
}
