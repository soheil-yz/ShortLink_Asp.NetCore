using Microsoft.EntityFrameworkCore;
using shortLink.Domain.Interface;
using shortLink.Domain.Models.Account;
using shortLink.Domain.ViewModel.Account;
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

        public async Task AddUser(User user)
        {
            await _context.users.AddAsync(user);
        }

        public async ValueTask DisposeAsync()
        {
            if(_context != null) 
                await _context.DisposeAsync();
        }

        public async Task<List<UserForShowViewModel>> GetAllUsersForShow()
        {
            var Alluser = await _context.users.AsQueryable().Select(u => new UserForShowViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Mobile = u.Mobile,
                IsAdmin = u.IsAdmin,
                IsBlock = u.IsBlock,    

            }).ToListAsync();
            return Alluser;
        }

        public async Task<User> GetUserByMobile(string mobile)
        {
            return await _context.users.SingleOrDefaultAsync(u => u.Mobile == mobile);
        }

        public async Task<bool> IsExistMobile(string mobile)
        {
            return await _context.users.AnyAsync(u => u.Mobile == mobile);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
