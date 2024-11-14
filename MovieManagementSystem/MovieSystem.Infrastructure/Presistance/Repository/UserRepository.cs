using AutoMapper;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Data;
using MovieSystem.Infrastructure.Presistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(DBContextApplication context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        //public async Task<User> GetUserAsync(int userId)
        //{
            
        //    var applicationUser = await _context.Users.FindAsync(userId);
        //    return _mapper.Map<User>(applicationUser);
        //}
    }
}
