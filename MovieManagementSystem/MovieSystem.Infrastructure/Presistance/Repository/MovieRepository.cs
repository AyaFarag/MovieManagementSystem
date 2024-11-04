using Microsoft.EntityFrameworkCore;
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

        public async Task<Movie> GetMovieWithCategory(int id)
        {
            var movie = await _context.Movies.Include(c=>c.Category).FirstOrDefaultAsync(m=>m.Id == id);

            return movie;
        }

    }
}
