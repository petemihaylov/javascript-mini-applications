using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.Extensions.Configuration;
using WebApi.Dtos;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("api/Account/authenticate")]
        [HttpPost]
        public ActionResult<UserDto> Authenticate(AuthDto authDto)
        {
            var userDto = _authService.Authenticate(authDto);

            if (userDto != null) return Ok(userDto);

            return BadRequest(new {message = "Couldn't authenticate."});
        }

        [Route("/api/Account/register")]
        [HttpPost]
        public ActionResult Register(RegisterDto registerDto)
        {
            var user = _authService.Register(registerDto.User, registerDto.Password);
            if (user != null) return Ok();

            return Conflict(new {message = "Couldn't register."});
        }
    }
}