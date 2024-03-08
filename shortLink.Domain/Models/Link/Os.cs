using shortLink.Domain.Models.Commend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Models.Link
{
    public class Os : BaseEntitiy
    {

        [Required]
        [MaxLength(255)]
        public string Major { get; set; }

        [Required]
        [MaxLength(255)]
        public string Family { get; set; }

        [Required]
        [MaxLength(255)]
        public string Minor { get; set; }
    }
}
