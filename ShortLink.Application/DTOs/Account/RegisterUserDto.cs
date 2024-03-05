using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.DTOs.Account
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(200)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
    }
    public enum RegisterUserResult
    {
        IsMobileExist,
        Success,
        
    }
}
