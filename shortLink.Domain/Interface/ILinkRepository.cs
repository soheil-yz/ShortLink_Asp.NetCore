using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Interface
{
    public interface ILinkRepository : IAsyncDisposable
    {
        Task SaveChange();

    }
}
