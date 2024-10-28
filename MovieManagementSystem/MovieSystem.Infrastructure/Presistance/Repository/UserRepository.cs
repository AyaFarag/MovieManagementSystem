using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Infrastructure.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(DBContextApplication context) : base(context)
        {
        }
    }
}
