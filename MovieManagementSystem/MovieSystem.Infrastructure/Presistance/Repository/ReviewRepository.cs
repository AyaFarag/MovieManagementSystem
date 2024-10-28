using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class ReviewRepository : Repository<Review> , IReviewRepository
    {
        public ReviewRepository(DBContextApplication context) : base(context)
        {
        }
    }
}
