using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class AuthDto
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}