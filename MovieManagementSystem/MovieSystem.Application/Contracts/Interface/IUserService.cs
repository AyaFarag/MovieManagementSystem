using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface IUserService 
    {
        Task<IEnumerable<UserDTO>> GetALlUsers();
        Task<User> GetUserById(string id);
        Task<UserDetailsDTO> CreateUser(UserDTO user);
        Task<User> UpdateCategory(int id, UserUpdateDTO movie);
        Task DeleteCategory(int id);
    }
}
