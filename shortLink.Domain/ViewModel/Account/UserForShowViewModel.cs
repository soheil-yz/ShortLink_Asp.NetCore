using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.ViewModel.Account
{
    public class UserForShowViewModel
    {
        public long Id { get; set; }     
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string MobileActiceCode { get; set; }
        public bool IsMobileActive { get; set; }
        public bool IsBlock { get; set; }
        public bool IsAdmin { get; set; }
    }
}
