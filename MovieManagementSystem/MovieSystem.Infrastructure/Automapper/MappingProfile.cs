using AutoMapper;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Models;


namespace MovieSystem.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map ApplicationUser to User
            CreateMap<ApplicationUser, User>()
                .ReverseMap();
            CreateMap<ApplicationRole, Role>()
                .ReverseMap();
        }
    }
}
