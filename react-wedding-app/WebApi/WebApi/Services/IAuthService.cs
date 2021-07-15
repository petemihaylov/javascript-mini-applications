using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Dtos;

namespace WebApi.Services
{
    public interface IAuthService
    {
        UserDto Authenticate(AuthDto authDto);
        User Register(User user, string password);
    }
}