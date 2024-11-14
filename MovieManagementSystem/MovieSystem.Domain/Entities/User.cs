using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieSystem.Domain.Entities
{
    public class User 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool isAdmin { get; set; }
        public bool isPaid { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Review> Reviews { get; set; }
        

     
        

        
        

     
        


        

    }
}
