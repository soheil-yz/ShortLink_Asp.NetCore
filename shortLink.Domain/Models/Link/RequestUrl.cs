using shortLink.Domain.Models.Commend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Models.Link
{
    public class RequestUrl : BaseEntitiy
    {
        public long ShortUrlId { get; set; }
        public DateTime RequestDatetime { get; set; }


        public ShortUrl ShortUrl { get; set; }
    }
}
