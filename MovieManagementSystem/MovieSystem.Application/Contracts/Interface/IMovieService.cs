using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetALlMovies();
        Task<Movie> GetMovieById(string id);
        Task<MovieDetailsDTO> CreateMovie(MovieDTO movie);
        Task<Movie> UpdateMovie(int id , MovieUpdateDTO movie);
        Task DeleteMovie(int id);
        Task<bool> HasUserWatchedMovieAsync(string userId, string movieId);
    }
}
