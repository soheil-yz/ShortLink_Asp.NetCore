using shortLink.Domain.Interface;
using shortLink.Domain.Models.Account;
using ShortLink.Application.DTOs.Account;
using ShortLink.Application.Interfaces;

namespace ShortLink.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _password;

        public UserService(IUserRepository userRepository , IPasswordHelper password)
        {
            _userRepository = userRepository;
            _password = password;
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
                    Password = _password.EcondePasswordMd5(registerUser.Password),
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
        public async Task<LoginUserResult> LoginUser(LoginUserDto loginUser)
        {
            var user = await _userRepository.GetUserByMobile(loginUser.Mobile);
            if(user == null) return LoginUserResult.NotFound;
            if(!user.IsMobileActive) return LoginUserResult.NotActivate;
            if(user.Password != _password.EcondePasswordMd5(loginUser.Password)) return LoginUserResult.NotFound;

             return LoginUserResult.Success;
        }

    }
}
