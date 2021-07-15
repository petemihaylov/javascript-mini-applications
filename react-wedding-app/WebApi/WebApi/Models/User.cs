using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User
    {
        
        [Key] public Guid Id { get; set; }
        [Required] public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [MaxLength(250)] public string FirstName { get; set; }

        [MaxLength(250)] public string LastName { get; set; }
    }
}