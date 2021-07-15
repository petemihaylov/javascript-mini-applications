using AutoMapper;
using WebApi.Models;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            // Source to Destination
            CreateMap<UserDto, User>();
        }
    }
}