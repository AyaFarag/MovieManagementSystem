using AutoMapper;
using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities;


namespace MovieSystem.Application.Automapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDTO , Movie>().ReverseMap();
            CreateMap<MovieDetailsDTO, Movie>().ReverseMap();
            CreateMap<MovieUpdateDTO, Movie>().ReverseMap();
        }
    }
}
