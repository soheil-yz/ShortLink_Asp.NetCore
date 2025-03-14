﻿using Microsoft.Extensions.DependencyInjection;
using shortLink.Domain.Interface;
using ShortLink.Application.Interfaces;
using ShortLink.Application.Services;
using ShortLink.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShortLink.Infra.Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            #region repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILinkRepository, LinkRepository>();

            #endregion

            #region service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILinkService, LinkService>();
            #endregion


            #region tools
            services.AddScoped<IPasswordHelper, PasswordHalper>();
            #endregion


        }


    }
}
