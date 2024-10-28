using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Data;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class MovieRepository : Repository<Movie> , IMovieRepository
    {

        public MovieRepository(DBContextApplication context) : base(context)
        {
        }

        //

    }
}
