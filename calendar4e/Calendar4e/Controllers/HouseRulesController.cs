using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Calendar4e.Data;
using Calendar4e.Models;

namespace Calendar4e.Controllers
{
    public class HouseRulesController : Controller
    {
        private readonly TaskContext db = new TaskContext();

        // GET: /HouseRules/Index
        public ActionResult Index()
        {
            HouseViewModel houseViewModel = new HouseViewModel();
            houseViewModel.houseRule =  new HouseRule();
            houseViewModel.listRules = db.HouseRules.ToList();
            return View(houseViewModel);
        }
    }
}