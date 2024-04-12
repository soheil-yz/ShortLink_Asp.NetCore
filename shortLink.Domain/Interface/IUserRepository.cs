using shortLink.Domain.Models.Account;
using shortLink.Domain.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Interface
{
    public interface IUserRepository : IAsyncDisposable
    {
        Task AddUser(User user);
        Task SaveChange();
        Task<bool> IsExistMobile(string mobile);
        Task<User> GetUserByMobile(string mobile);
        Task<List<UserForShowViewModel>> GetAllUsersForShow(); 
    }
}
