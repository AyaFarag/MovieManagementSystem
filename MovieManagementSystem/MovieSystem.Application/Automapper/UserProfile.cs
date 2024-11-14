using AutoMapper;
using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities;

namespace MovieSystem.Application.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterModel, User>()
                .ForMember(p => p.PasswordHash, opt => opt.MapFrom(src => src.Password));
            
            CreateMap<User, RegisterModel>()
                .ForMember(p => p.Password, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserDetailsDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();

        }
    }
}
