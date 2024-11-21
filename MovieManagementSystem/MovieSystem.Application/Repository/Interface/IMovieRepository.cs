using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Repository.Interface
{
    public interface IMovieRepository : IRepository<Movie>
    {
        //Task<Movie> GetMovieWithCategory(int id);
        bool isUserWatched(string userId, string movieId);
    }
}
