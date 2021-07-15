
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Calendar4e.Data;
using Calendar4e.Models;

namespace Calendar4e.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly TaskContext db = new TaskContext();

        // GET: Complaints
        public ActionResult Index()
        {
            return View(db.Complaints.ToList());
        }

        // GET: Complaints/Delete/5
        public ActionResult Delete(long? id)
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
            return RedirectToAction("Index", "Task");
        }

        // POST: Complaints/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Description, DirectedToUser, IsPublic")] Complaint @complaint)
        {
            if (ModelState.IsValid)
            {
                Student student = (Student)Session["Student"];
                complaint.Date = DateTime.Now.ToString();
                complaint.Student = student;
                
                db.Complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaint);
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