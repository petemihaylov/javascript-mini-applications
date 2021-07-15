using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar4e.Models
{
    public class HouseRule
    {
        [Key]
        public int ID { get; set; }
        public String Description { get; set; }
    }
}