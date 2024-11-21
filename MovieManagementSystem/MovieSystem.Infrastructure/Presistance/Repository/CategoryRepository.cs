using Microsoft.EntityFrameworkCore;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        //private readonly DBContextApplication _context;
        public CategoryRepository(DBContextApplication context) : base(context)
        {
                
        }

        //public async Task<IEnumerable<Category>> GetAllCategoriesWithMoviesAsync()
        //{
        //    return await _context.Categories.Include(m=>m.Movies).ToListAsync();
        //}
        //public async Task<Category> GetCategoryByIdWithMoviesAsync(int id)
        //{
        //    return await _context.Categories.Include(m => m.Movies).Where(c => c.Id == id).FirstOrDefaultAsync();
        //}

    }
}
