using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDetailsDTO>> GetALlCategories();
        Task<CategoryDetailsDTO> GetCategoryById(int id);
        Task<CategoryDetailsDTO> CreateCategory(CategoryDTO movie);
        Task<Category> UpdateCategory(int id, CategoryUpdateDTO movie);
        Task DeleteCategory(int id);
    }
}
