using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Calendar4e.Data;
using Calendar4e.Models;

namespace Calendar4e.Controllers
{
    public class EventsController : Controller
    {
        private EventContext db = new EventContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }


        public JsonResult GetEvents()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var events = db.Events.ToList();
            return Json(events, JsonRequestBehavior.AllowGet);
        }





        // GET: Events/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Events/CreateComplaint
        public ActionResult CreateComplaint()
        {
            return View();
        }


        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,subject,description,start,end,allDay")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.StudentId = 1;
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }
        // POST: Events/CreateComplaint
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComplaint([Bind(Include = "id, title, description, date, email")] Complaint @complaint)
        {
            if (ModelState.IsValid)
            {
                @complaint.id = 1;
                @complaint.date = DateTime.Now.ToString("yyyy-MM-dd T HH:mm");
                db.Complaints.Add(@complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@complaint);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subject,description,start,end,allDay")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
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
