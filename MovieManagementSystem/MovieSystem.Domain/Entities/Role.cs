using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
