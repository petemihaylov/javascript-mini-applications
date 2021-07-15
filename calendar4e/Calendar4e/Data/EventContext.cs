using System;
using System.Linq;
using System.Web;
using Calendar4e.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Calendar4e.Data
{
    public class EventContext : DbContext
    {
        public EventContext() : base("EventContext")
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}