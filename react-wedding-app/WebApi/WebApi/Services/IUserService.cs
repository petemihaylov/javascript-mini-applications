using System;
using System.Linq;
using WebApi.Models;
using WebApi.Dtos;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IUserService
    {
        public User AddUser(User user);

        Task<User> AddUserAsync(User user);

        public User DeleteUser(Guid id);

        Task<User> DeleteUserAsync(Guid id);

        public User GetUserById(Guid id);

        Task<User> GetUserByIdAsync(Guid id);

        public IQueryable<User> GetUsers();

        Task<IQueryable<User>> GetUsersAsync();

        public User UpdateUser(UserDto user);

        Task<User> UpdateUserAsync(UserDto user);
    }
}