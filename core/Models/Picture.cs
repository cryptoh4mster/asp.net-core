using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public int? UserId { get; set; }
        public byte[] Image { get; set; }
        public User User { get; set; }
    }
}
