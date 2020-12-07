using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        EduContext db = new EduContext();
        // GET: Admin/Branch
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Branch data)
        {
            Branch yeni = new Branch();
            yeni.Name = data.Name;

            db.Branches.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}