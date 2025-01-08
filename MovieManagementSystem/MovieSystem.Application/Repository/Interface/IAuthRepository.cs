using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Repository.Interface
{
    public interface IAuthRepository
    {
        // CRUD from identity
        Task<bool> CreateUserAsync(User user, List<string> role);
        Task<User> FindUserByEmailAsync(string email);
        Task<User> FindUserByNameAsync(string UserName);
        Task<bool> addUserToRoleAsync(User user , List<string> role);
        Task<bool> CheckLoginCredentialsAsync(string email, string password);
        Task<IList<string>> GetUserRoles(User user);
        Task<IList<Claim>> GetClaimsAsync(User user);
        //CheckPasswordAsync
        Task<bool> CheckUserPasswordAsync(User user, string password);


    }
}
