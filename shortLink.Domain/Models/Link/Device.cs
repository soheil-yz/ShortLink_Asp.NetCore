using shortLink.Domain.Models.Commend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Models.Link
{
    public class Device : BaseEntitiy
    {
        public bool IsBot { get; set; }

        [Required]
        [MaxLength(255)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(255)]
        public string Family { get; set; }

        [Required]
        [MaxLength(255)]
        public string Model { get; set; }
    }
}
