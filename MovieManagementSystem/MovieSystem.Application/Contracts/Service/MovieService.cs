using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;

namespace MovieSystem.Application.Contracts.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IUnitOfWork _unit;


        public MovieService(IMovieRepository repository, IUnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;
        }

        public Task<Movie> CreateMovie(MovieDTO movie)
        {
            // business logic
            // repository -> db
            // automapper DTO -> Object
            // var result = _repository.CreateMovie(automapper);
            // automapper
           
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieDTO>> GetALlMovies()
        {
            throw new NotImplementedException();
        }

        public Task<MovieDetailsDTO> GetMovieById()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(int id, MovieUpdateDTO movie)
        {
            throw new NotImplementedException();
        }
    }
}
