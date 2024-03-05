﻿using ShortLink.Application.DTOs.Account;
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
        
    }
}
