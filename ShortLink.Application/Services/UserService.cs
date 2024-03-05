using shortLink.Domain.Interface;
using shortLink.Domain.Models.Account;
using ShortLink.Application.DTOs.Account;
using ShortLink.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public async Task<RegisterUserResult> RegisterUser(RegisterUserDto registerUser)
        {
            if(!await _userRepository.IsExistMobile(registerUser.Mobile))
            {
                var user = new User
                {
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    Mobile = registerUser.Mobile,
                    //Password = registerUser.Password,
                    MobileActiceCode = new Random().Next(10000,999999999).ToString(),
                    LastUpDateData = DateTime.Now,
                    CreateData = DateTime.Now,
                };
                await _userRepository.AddUser(user);
                await _userRepository.SaveChange();
                return RegisterUserResult.Success;
            }
            return RegisterUserResult.IsMobileExist;
        }
    }
}
