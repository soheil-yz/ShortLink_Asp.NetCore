using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.DTOs.Links
{
    public class UrlRequestDto
    {
        [Required] 
        public  string OrginalUrl { get; set; }
    }
}
