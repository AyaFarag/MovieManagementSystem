using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Repository.Interface
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        IUserRepository Users { get; }
    }
}
