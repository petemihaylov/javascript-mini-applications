using Calendar4e.Data;
using Calendar4e.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calendar4e.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskContext db = new TaskContext();
        public ActionResult Login()
        {
            return View();
        }

        // GET: Home/Unauthorized
        public ActionResult Unauthorized()
        {
            return View();
        }

        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] Student @student)
        {
            if (ModelState.IsValid)
            {
                
                using (TaskContext db = new TaskContext())
                {
                    var obj = db.Students.Where(s => s.Username.Equals(@student.Username)).FirstOrDefault();

                    
                    if (obj != null)
                    {
                        if (Hashing.ValidatePassword(student.Password, obj.Password) == true)
                        {
                            Session["UserID"] = obj.StudentID.ToString();
                            Session["Username"] = obj.Username.ToString();
                            Session["Student"] = obj;
                            Session["Role"] = obj.Role;

                            // If Admin redirect to AdminController
                            if(obj.Role == RoleType.Admin.ToString())
                            {
                                return RedirectToAction("Index", "Admin");
                            }

                            return RedirectToAction("Index", "Task");
                        }
                    }
                }
            }

            @ViewBag.Error = "Invalid username or password!";
            return View("Login");
        }
        public ActionResult Register()
        {
                return View();
        }

        // POST: Home/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username,Password")] Student @student)
        {
            if (ModelState.IsValid)
            {
                using (TaskContext db = new TaskContext())
                {
                    if (this.GetStudentByName(student.Username) == null) 
                    {
                        Student s = new Student
                        {
                            Username = student.Username,
                            Password = Hashing.HashPassword(student.Password),
                            EnrollmentDate = DateTime.Now.ToString("yyyy-MM-ddThh:mm tt"),
                            ThemeColor = "purple",
                            Role = RoleType.User.ToString(),
                            IsActive = true
                        };


                        db.Students.Add(s);
                        db.SaveChanges();
                        return View("Login");
                    }
                    else
                    {
                        @ViewBag.Error = "User in use. Try with another one!";
                        return View("Register");
                    }
                    
                }

            }
            return View();
        }

        private Student GetStudentByName(string name)
        {
            foreach (var s in db.Students.ToList())
            {
                if (s.Username == name) return s;
            }
            return null;
        }

    }
}