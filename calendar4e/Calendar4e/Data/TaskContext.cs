using System;
using System.Linq;
using System.Web;
using Calendar4e.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Calendar4e.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("TaskContext")
        {
            

        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<HouseRule> HouseRules { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}