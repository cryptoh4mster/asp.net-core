using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Models
{
    public class User
    {
        public int Id { get; set;}
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public List<Picture> Pictures { get; set; }
        public Role Role { get; set; }
        public User()
        {
            Pictures = new List<Picture>();
        }
    }
}
