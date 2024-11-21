using AutoMapper;
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
        private readonly IMapper _mapper;


        public MovieService(IMovieRepository repository, IUnitOfWork unit, IMapper mapper)
        {
            _repository = repository;
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<MovieDetailsDTO> CreateMovie(MovieDTO movieDTO)
        {
            // business logic if , try , catch 
            // to create
            var movieCreate = _mapper.Map<Movie>(movieDTO);
            var repo = await _repository.AddAsync(movieCreate);
            // automapper DTO -> Object
            var movieDetails = _mapper.Map<MovieDetailsDTO>(repo);

            return movieDetails;
           
          
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieDTO>> GetALlMovies()
        {
            throw new NotImplementedException();
        }

        //public async Task<Movie> GetMovieById(string id)
        //{
        //   var movie = await _repository.GetMovieWithCategory(int.Parse(id));
        //   var response = _mapper.Map<MovieDetailsDTO>(movie);
        //    return movie;
        //}

        public Task<Movie> UpdateMovie(int id, MovieUpdateDTO movie)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasUserWatchedMovieAsync(string userId, string movieId)
        {
            var isUserWatched =  _repository.isUserWatched(userId , movieId);
              return isUserWatched ;
        }

        public Task<Movie> GetMovieById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
