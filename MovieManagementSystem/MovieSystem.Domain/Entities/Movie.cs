using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
