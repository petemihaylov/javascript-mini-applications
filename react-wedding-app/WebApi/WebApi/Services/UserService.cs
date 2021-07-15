using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Contracts;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IRepositoryWrapper repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public User AddUser(User user)
        {
            _repository.User.Create(user);
            _repository.Save();
            return user;
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await Task.FromResult(AddUser(user));
        }

        public User DeleteUser(Guid id)
        {
            var user = GetUserById(id);
            _repository.User.Delete(user);
            _repository.Save();
            return user;
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            return await Task.FromResult(DeleteUser(id));
        }

        public User GetUserById(Guid id)
        {
            try
            {

                return _repository.User.FindByCondition(u => u.Id.Equals(id)).First();
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await Task.FromResult(GetUserById(id));
        }

        public IQueryable<User> GetUsers()
        {
            return _repository.User.FindAll();
        }

        public async Task<IQueryable<User>> GetUsersAsync()
        {
            return await Task.FromResult(GetUsers());
        }

        public User UpdateUser(UserDto userDto)
        {
            var user = GetUserById(userDto.Id);
            _mapper.Map(userDto, user);
            _repository.User.Update(user);
            _repository.SaveAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(UserDto userDto)
        {
            return await Task.FromResult(UpdateUser(userDto));
        }
    }
}