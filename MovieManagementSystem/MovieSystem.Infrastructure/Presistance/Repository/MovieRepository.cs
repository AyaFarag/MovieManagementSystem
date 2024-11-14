using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
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

        public async Task<bool> isUserWatched(string userId, string movieId)
        {
            // Implement logic to check if user has watched the movie
            var watchRecord = await _context.UserMovies
                .FirstOrDefaultAsync(w => w.userId == int.Parse(userId) && w.movieId == int.Parse(movieId));

            return watchRecord != null;
        }

    }
}
