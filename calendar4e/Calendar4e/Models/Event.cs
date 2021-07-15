using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar4e.Models
{
    public class Event
    {
        [Key]
        public Int64 id { get; set; }

        public String subject { get; set; }

        public String description { get; set; }

        public String start { get; set; }

        public String end { get; set; }

        public bool allDay { get; set; } = false;

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}