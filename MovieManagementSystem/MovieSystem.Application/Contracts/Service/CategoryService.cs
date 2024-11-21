using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
             _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDetailsDTO> CreateCategory(CategoryDTO movie)
        {
            var cat = _mapper.Map<Category>(movie);
            var createCat = await _categoryRepository.AddAsync(cat);
            var response = _mapper.Map<CategoryDetailsDTO>(createCat);
            return response;
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDetailsDTO>> GetALlCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDetailsDTO> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<CategoryDetailsDTO>> GetALlCategories()
        //{
        //    var cats = await _categoryRepository.GetAllCategoriesWithMoviesAsync();
        //    var response = _mapper.Map<IEnumerable<CategoryDetailsDTO>>(cats);
        //    return response;
        //}

        //public async Task<CategoryDetailsDTO> GetCategoryById(int id)
        //{
        //    var cat = await _categoryRepository.GetCategoryByIdWithMoviesAsync(id);
        //    var response =  _mapper.Map<CategoryDetailsDTO>(cat);
        //    return response;
        //}

        public Task<Category> UpdateCategory(int id, CategoryUpdateDTO movie)
        {
            throw new NotImplementedException();
        }
    }
}
