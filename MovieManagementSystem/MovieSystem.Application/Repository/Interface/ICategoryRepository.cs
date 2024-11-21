using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Repository.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Task<IEnumerable<Category>> GetAllCategoriesWithMoviesAsync();
        //Task<Category> GetCategoryByIdWithMoviesAsync(int id);
    }
}
