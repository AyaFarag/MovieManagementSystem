using MovieSystem.Application.Repository.Interface;
using MovieSystem.Infrastructure.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContextApplication _context;
        private IMovieRepository _movies;
        private IUserRepository _users;
        public UnitOfWork(DBContextApplication context)
        {
            _context = context;
        }

        public IMovieRepository Movies => _movies ??= new MovieRepository(_context);
        public IUserRepository Users => _users ??= new UserRepository(_context);

    }
}
