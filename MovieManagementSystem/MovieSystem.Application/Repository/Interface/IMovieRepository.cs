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
        //Task<IEnumerable<Movie>> GetALlMovies();
        //Task<Movie> GetMovieById();
        //Task<Movie> CreateMovie(Movie movie);
        //Task<Movie> UpdateMovie(Movie movie);
        //Task DeleteMovie(int id);
    }
}
