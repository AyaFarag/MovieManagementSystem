using Microsoft.AspNetCore.Identity;
using MovieSystem.Domain.Entities;


namespace MovieSystem.Infrastructure.Presistance.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        public bool isPaid { get; set; }
        public ICollection<Review> Reviews { get; set; }


    }
}
