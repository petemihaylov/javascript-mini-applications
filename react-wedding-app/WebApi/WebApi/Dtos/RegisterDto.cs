using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Dtos
{
    public class RegisterDto
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}