using shortLink.Domain.Models.Account;
using shortLink.Domain.ViewModel.Account;
using ShortLink.Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserResult> RegisterUser(RegisterUserDto registerUser);
        Task<LoginUserResult> LoginUser(LoginUserDto loginUser);
        Task<User> GetUserByMobile(string mobile);
        Task<List<UserForShowViewModel>> GetUserFors();    
        
    }
}
