using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Models
{
    public class UserMoviesModel
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
