using System;
using System.Linq;
using System.Web;
using Calendar4e.Models;
using System.Collections.Generic;

namespace Calendar4e.Data
{
        public class EventInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EventContext>
        {
            protected override void Seed(EventContext context)
            {
                var students = new List<Student>
            {
                new Student{name="Alonso",enrollmentDate=DateTime.Parse("2002-09-01").ToString(), themeColor = "red", isActive=true},
                new Student{name="Gosho",enrollmentDate=DateTime.Parse("2003-09-01").ToString(), themeColor = "blue", isActive=true},
                new Student{name="Tosho",enrollmentDate=DateTime.Parse("2002-09-01").ToString(), themeColor = "green", isActive=true}
            };
                students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();

                var events = new List<Event>
            {
                new Event{subject="subject1", StudentId = 1, description="description", start=DateTime.Parse("2019-12-09 05:50 PM").ToString("yyyy-MM-ddTHH:mm"), end=DateTime.Parse("2019-12-09 06:50 PM").ToString("yyyy-MM-ddTHH:mm")},
                new Event{subject="subject2", StudentId = 1, description="description", start=DateTime.Parse("2019-12-08 01:50 PM").ToString("yyyy-MM-ddTHH:mm"), end=DateTime.Parse("2019-12-09 02:50 PM").ToString("yyyy-MM-ddTHH:mm")},
                new Event{subject="subject3", StudentId = 1,description="description", start=DateTime.Parse("2019-12-07 02:50 PM").ToString("yyyy-MM-ddTHH:mm"), end=DateTime.Parse("2019-12-09 03:50 PM").ToString("yyyy-MM-ddTHH:mm")},

            };
                events.ForEach(s => context.Events.Add(s));
                context.SaveChanges();

            var complaints = new List<Complaint>
            {
                new Complaint{title="you didn't wash the dishes again",email = "sladka_ani4ka@mail.bg", description = "you're the worst roommate I've ever had", date = DateTime.Parse("2019-12-09 05:00 PM").ToString("yyyy-MM-ddTHH:mm")},
                new Complaint{title="you ate some of my stroopwafels", email = "kosio@hotmail.com", description = "thought I wouldn't notice?", date = DateTime.Parse("2019-12-09 05:00 PM").ToString("yyyy-MM-ddTHH:mm")},
                new Complaint{title="I dont like you", email = "pepiiiii@gmail.com", description = "I really dont", date = DateTime.Parse("2019-12-09 05:00 PM").ToString("yyyy-MM-ddTHH:mm")}
            };
            complaints.ForEach(c => context.Complaints.Add(c));
            context.SaveChanges();
        }
        }

}