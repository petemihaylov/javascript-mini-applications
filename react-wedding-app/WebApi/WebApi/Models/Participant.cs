using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Participant
    {
        [Key] public Guid Id { get; set; }
        [MaxLength(250)] public string FirstName { get; set; }

        [MaxLength(250)] public string LastName { get; set; }

        [MaxLength(250)] public string Email { get; set; }
        
    }
}