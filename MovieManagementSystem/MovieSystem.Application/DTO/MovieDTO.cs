using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.DTO
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
    }

    public class MovieDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryUpdateDTO Category { get; set; }
    }

    

}
