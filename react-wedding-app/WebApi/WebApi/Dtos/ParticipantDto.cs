using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class ParticipantDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
    }
}