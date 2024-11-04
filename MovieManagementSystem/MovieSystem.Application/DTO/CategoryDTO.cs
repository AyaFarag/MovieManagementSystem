using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
    }
    public class CategoryDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieDetailsDTO> Movies { get; set; }
    }
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
