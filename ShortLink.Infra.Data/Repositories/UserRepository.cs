using shortLink.Domain.Interface;
using ShortLink.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShortLinkContext _context;
        public UserRepository(ShortLinkContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync()
        {
            if(_context != null) 
                await _context.DisposeAsync();
        }
    }
}
