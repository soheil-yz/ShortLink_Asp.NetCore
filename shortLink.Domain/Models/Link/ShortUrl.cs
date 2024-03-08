using shortLink.Domain.Models.Commend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Models.Link
{
    public class ShortUrl : BaseEntitiy
    {

        [Required]
        public Uri orginalUrl { get; set; }

        [Required]
        [MaxLength(255)]
        public Uri Value { get; set; }

        [Required]
        [MaxLength(40)]
        public string Token { get; set; }

        public ICollection<RequestUrl> RequestUrl { get; set; }
    }
}
