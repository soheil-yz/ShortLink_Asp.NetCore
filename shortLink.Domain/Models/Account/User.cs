using shortLink.Domain.Models.Commend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Models.Account
{
    public class User : BaseEntitiy
    {
        public string Mobile {  get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20 ,ErrorMessage ="Long Strig")]
        public string MobileActiceCode { get; set; }
        public bool IsMobileActive { get; set; }
        public bool IsBlock { get; set; }
    }
}
