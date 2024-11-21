using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using MovieSystem.Infrastructure.Presistance.Models;
using System.Security.Claims;


namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public AuthRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> addUserToRoleAsync(User user, string role)
        {
            var result = false;
            
            var applicationuser =  _mapper.Map<ApplicationUser>(user);
            var addrole = await _userManager.AddToRoleAsync(applicationuser, role);
            if(addrole != null) result = true;
            
            return result;
        }

        public async Task<bool> CheckUserPasswordAsync(User user, string password)
        {
            var applicationuser = _mapper.Map<ApplicationUser>(user);
            return await _userManager.CheckPasswordAsync(applicationuser, password);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var applicationuser =  _mapper.Map<ApplicationUser>(user);
            var result = await _userManager.CreateAsync(applicationuser, user.PasswordHash);
            return result.Succeeded;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            var applicationuser = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<User>(applicationuser);
        }

        public async Task<User> FindUserByNameAsync(string UserName)
        {
            var applicationuser = await _userManager.FindByNameAsync(UserName);
            return _mapper.Map<User>(applicationuser);
        }

        public async Task<IList<Claim>> GetClaimsAsync(User user)
        {
            var applicationuser = _mapper.Map<ApplicationUser>(user);
            var claims = await _userManager.GetClaimsAsync(applicationuser);
            //var listCliams = _mapper.Map<List<string>>(claims);
            return claims;
        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            var applicationuser = _mapper.Map<ApplicationUser>(user);
            var roles = await _userManager.GetRolesAsync(applicationuser);
            return roles;
        }

        public async Task<bool> CheckLoginCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            return await _userManager.CheckPasswordAsync(user, password);
        }

        
    }
}
