using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Extentions;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieSystem.Application.Contracts.Service
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;
        //private readonly IConfiguration _configuration;
        //private readonly ILoginAttemptService _loginAttemptService;
        public AccountService(IAuthRepository authRepository
            , IMapper mapper
            , IOptions<JWT> jwt
           // , LoginAttemptService loginAttemptService
            , ILogger<AccountService> logger)
        {
             _authRepository = authRepository;
            _mapper = mapper;
            _jwt = jwt.Value;
          //  _loginAttemptService = loginAttemptService;
            _logger = logger;
        }
        private async Task<AuthModel> CheckExistUser(RegisterModel model)
        {
            if (await _authRepository.FindUserByEmailAsync(model.Email) is not null) // FindUserByEmail
            {
                _logger.LogInformation("Email is already registered!");
                return new AuthModel { Message = "Email is already registered!" };
            }
             
            if (await _authRepository.FindUserByNameAsync(model.userName) is not null) // FindUserByUserName
            {
                _logger.LogInformation("Username is already registered!");
                return new AuthModel { Message = "Username is already registered!" };

            }

            return new AuthModel { Message = "" };
        }
        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            _logger.LogInformation("Registering user {Email}", model.Email);

            var user =  _mapper.Map<User>(model); // including password
            var result = await _authRepository.CreateUserAsync(user); // create user
         //   await _authRepository.addUserToRoleAsync(user, model.Roles); // addUserToRoleAsync

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Email = model.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = model.userName
            };

        }
        public async Task<AuthModel> LoginAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();
            var result = await _authRepository.CheckLoginCredentialsAsync(model.Email, model.Password);

            //if (result == false || await _loginAttemptService.IsThrottledAsync(model.Email))
            //{
            //    // warning
            //    _logger.LogWarning("Failed to login user {Email}", model.Email);
            //    _logger.LogInformation("Too many login attempts. Please try again later.");
            //    return new AuthModel { Message = "Too many login attempts. Please try again later." };
            //}
            if (result == false)
            {
                _logger.LogWarning("Email or Password is incorrect!");
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var user = await _authRepository.FindUserByEmailAsync(model.Email);
            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _authRepository.GetUserRoles(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.userName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
           
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var roles = await _authRepository.GetUserRoles(user); // GetUserRoles

            var userClaims = await  _authRepository.GetClaimsAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

       
    }
}
