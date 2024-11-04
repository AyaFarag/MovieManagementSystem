using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Domain.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
