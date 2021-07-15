using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Contracts;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration, IRepositoryWrapper repository)
        {
            this._configuration = configuration;
            this._repository = repository;
        }


        public UserDto Authenticate(AuthDto authDto)
        {
            try
            {
                
                // Checks if the user exists
                var user = _repository.User.FindByCondition(u => u.Username.Equals(authDto.Username)).First();

                // Verifies the password of the user
                if (!VerifyPassword(authDto.Password, user.PasswordHash, user.PasswordSalt))
                    return null;

                // Create claims details based on the user information
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName)
                };
                
                // Generating the token with HmacSha256
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(this._configuration["Jwt:Issuer"], this._configuration["Jwt:Audience"], claims,
                    expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);


                return new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    AccessToken = accessToken
                };

            }
            catch (Exception)
            {
                return null;
            }

           
        }

        public User Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.Id = Guid.NewGuid();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _repository.User.Create(user);
            _repository.Save();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;
            }

            return true;
        }
    }
}