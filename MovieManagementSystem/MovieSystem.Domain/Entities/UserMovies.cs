using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Domain.Entities
{
    public class UserMovies
    {
        public int userId { get; set; }
        public User User { get; set; }

        public int movieId { get; set; }
        public Movie Movie { get; set; }
    }
}
