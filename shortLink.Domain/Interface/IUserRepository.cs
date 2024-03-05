using shortLink.Domain.Models.Account;
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

    }
}
