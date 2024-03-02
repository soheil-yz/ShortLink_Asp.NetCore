using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortLink.Domain.Models.Commend
{
    public class BaseEntitiy
    {
        [Key]
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime LastUpDateData { get; set; }
    }
}
