using Calendar4e.Data;
using Calendar4e.Models;
using EntityFramework.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Calendar4e.Controllers
{
    //      Route /Admin
    public class AdminController : Controller
    {
        private readonly TaskContext db = new TaskContext();

        // GET: /
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Complaints/
        public ActionResult Complaints()
        {
            return View(db.Complaints.ToList());
        }

        // GET: /EditUser/5
        public ActionResult EditUser(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (@student == null)
            {
                return HttpNotFound();
            }
            return View(@student);
        }

        // POST: /EditUser/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "StudentID,Username,Password,ThemeColor, EnrollmentDate, Role")] Student @student)
        {

            if (ModelState.IsValid)
            {
                
                db.Students.Where(x => x.StudentID == student.StudentID)
                .Update(u => new Student()
                {
                    Username = student.Username,
                    ThemeColor = student.ThemeColor
                });
                 
                db.SaveChanges();
                
                return RedirectToAction("Users", "Admin");
            }
            return View(@student);
        }

        // GET: /DeleteComplaint/5
        public ActionResult DeleteComplaint(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint @complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            db.Complaints.Remove(@complaint);
            db.SaveChanges();
            return RedirectToAction("Complaints", "Admin");
        }

        //GET: /DeleteUser/5
        public ActionResult DeleteUser(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student @user = db.Students.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            
            // Delete Complaints of the user
            foreach (var c in db.Complaints.ToList())
            {
                if(c.Student.StudentID == user.StudentID)
                {
                    db.Complaints.Remove(c);
                }
            }

            // Delete Taks of the user
            foreach (var t in db.Tasks.ToList())
            {
                if (t.Student.StudentID == user.StudentID)
                {
                    db.Tasks.Remove(t);
                }
            }

            db.Students.Remove(@user);
            db.SaveChanges();
            return RedirectToAction("Users", "Admin");
        }


        //GET: /Admin/Users
        public ActionResult Users()
        {
            return View(db.Students.ToList());
        }

        //GET: /Admin/HouseRules
        public ActionResult HouseRules()
        {
            HouseViewModel hrModel = new HouseViewModel();

            hrModel.listRules = db.HouseRules.ToList();
            hrModel.houseRule = new HouseRule();
            return View(hrModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRule([Bind(Include = "Description")] HouseRule houseRule)
        {
            if (ModelState.IsValid)
            {
                db.HouseRules.Add(houseRule);
                db.SaveChanges();
                return RedirectToAction("HouseRules");
            }

            return View("HouseRules");
        }

        //GET: /Admin/DeleteRule/5
        public ActionResult DeleteRule(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseRule @houseRule = db.HouseRules.Find(id);
            if (@houseRule == null)
            {
                return HttpNotFound();
            }
            db.HouseRules.Remove(@houseRule);
            db.SaveChanges();
            return RedirectToAction("HouseRules", "Admin");
        }

        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Home");

        }

        public JsonResult GetChartInfo()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            


           List<Chart> items = new List<Chart>();

            var students = db.Students;

            foreach (var s in students)
            {
                if(s.Role != RoleType.Admin.ToString())
                {
                    double count = (double)db.Tasks.Where(t => t.Student.Username == s.Username).Count();
                    items.Add(new Chart(count, s.Username));
                }
            }

            var json = items.ToArray();

            return Json(json, JsonRequestBehavior.AllowGet);

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}