using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities;

namespace MovieSystem.Application.Automapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO , Category>().ReverseMap();
            CreateMap<CategoryDetailsDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();

        }
    }
}
