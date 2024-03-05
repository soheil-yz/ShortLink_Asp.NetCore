using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.DTOs.Account
{
    public class LoginUserDto
    {
        [Required]
        [MaxLength(200)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
    public enum LoginUserResult
    {
        NotFound,
        NotActivate,
        Success
    }
}
