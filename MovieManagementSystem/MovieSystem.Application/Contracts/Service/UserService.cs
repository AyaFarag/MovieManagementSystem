using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserDetailsDTO> CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetALlUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateCategory(int id, UserUpdateDTO movie)
        {
            throw new NotImplementedException();
        }
    }
}
