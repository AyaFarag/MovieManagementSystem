using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Models
{
    public class ReviewModel : Review
    {
        public ApplicationUser User { get; set; }
    }
}
