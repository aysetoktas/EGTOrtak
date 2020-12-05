using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class UnitController : Controller
    {
        EduContext db = new EduContext();
        // GET: Admin/Unit
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.EducationID).ToList();
            return View(lessons);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Unit data)
        {
            Unit yeni = new Unit();
            yeni.Name = data.Name;
            yeni.EducationID = data.EducationID;

            db.Units.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}