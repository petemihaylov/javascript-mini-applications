using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar4e.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [DataType(DataType.Text)]
        [Column("Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Column("Password")]
        public string Password { get; set; }
        public string ThemeColor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string EnrollmentDate { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}