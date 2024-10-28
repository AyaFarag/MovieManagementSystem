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
        Task<MovieDetailsDTO> GetMovieById();
        Task<Movie> CreateMovie(MovieDTO movie);
        Task<Movie> UpdateMovie(int id , MovieUpdateDTO movie);
        Task DeleteMovie(int id);
    }
}
