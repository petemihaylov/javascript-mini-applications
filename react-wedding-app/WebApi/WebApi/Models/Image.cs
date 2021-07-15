using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Image 
    {       
        [Key] public Guid Id { get; set; }
        public string Url { get; set; }
    }
}